$ErrorActionPreference = "Stop"

$sourcePath = Join-Path (Get-Location) "TCSA.V2026/Data/Curriculum/BlogHelper.cs"
$imageDirectory = Join-Path (Get-Location) "TCSA.V2026/wwwroot/img/blog/legacy"
$utf8 = [System.Text.UTF8Encoding]::new($false)
$source = [System.IO.File]::ReadAllText($sourcePath, [System.Text.Encoding]::UTF8)
$urlPattern = 'https://[^\s\"''\\]+?\.(?:png|jpe?g|gif|webp)'
$urls = @([regex]::Matches($source, $urlPattern, [System.Text.RegularExpressions.RegexOptions]::IgnoreCase) |
    ForEach-Object Value |
    Where-Object { ([Uri]$_).Host -match '(?:wordpress\.com|wp\.com)$' } |
    Sort-Object -Unique)

[System.IO.Directory]::CreateDirectory($imageDirectory) | Out-Null
$downloaded = 0
$unavailable = [System.Collections.Generic.List[string]]::new()

foreach ($url in $urls) {
    $uri = [Uri]$url
    $originalName = [System.IO.Path]::GetFileName($uri.AbsolutePath)
    $safeName = [regex]::Replace([Uri]::UnescapeDataString($originalName).ToLowerInvariant(), '[^a-z0-9._-]', '-')
    $hashBytes = [System.Security.Cryptography.SHA256]::Create().ComputeHash([System.Text.Encoding]::UTF8.GetBytes($url))
    $hash = ([System.BitConverter]::ToString($hashBytes)).Replace('-', '').Substring(0, 10).ToLowerInvariant()
    $localName = "$hash-$safeName"
    $destination = Join-Path $imageDirectory $localName

    if (-not (Test-Path -LiteralPath $destination) -or (Get-Item $destination).Length -eq 0) {
        & curl.exe --fail --location --silent --show-error --max-time 60 --output $destination $url
        if ($LASTEXITCODE -ne 0 -or -not (Test-Path -LiteralPath $destination) -or (Get-Item $destination).Length -eq 0) {
            Remove-Item -LiteralPath $destination -Force -ErrorAction SilentlyContinue
            $unavailable.Add($url)
            continue
        }
        $downloaded++
    }

    $localUrl = "/img/blog/legacy/$localName"
    $referencePattern = [regex]::Escape($url) + '(?:\?[^\s\"''\\]*)?'
    $source = [regex]::Replace($source, $referencePattern, $localUrl, [System.Text.RegularExpressions.RegexOptions]::IgnoreCase)
}

[System.IO.File]::WriteAllText($sourcePath, $source, $utf8)
Write-Output "Localized $($urls.Count) image references ($downloaded downloaded) into $imageDirectory"
if ($unavailable.Count -gt 0) {
    Write-Warning "$($unavailable.Count) image(s) are no longer available from WordPress:"
    $unavailable | ForEach-Object { Write-Warning $_ }
}
