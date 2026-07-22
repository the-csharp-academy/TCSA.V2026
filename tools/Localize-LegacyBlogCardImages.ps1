$ErrorActionPreference = "Stop"

$site = "cappuccinocodes.wordpress.com"
$sourcePath = Join-Path (Get-Location) "TCSA.V2026/Data/Curriculum/BlogHelper.cs"
$cardDirectory = Join-Path (Get-Location) "TCSA.V2026/wwwroot/img/CardImages"
$utf8 = [System.Text.UTF8Encoding]::new($false)
$source = [System.IO.File]::ReadAllText($sourcePath, [System.Text.Encoding]::UTF8)
$posts = [System.Collections.Generic.List[object]]::new()

for ($page = 1; $page -le 2; $page++) {
    $tempFile = [System.IO.Path]::GetTempFileName()
    try {
        $uri = "https://public-api.wordpress.com/rest/v1.1/sites/$site/posts/?number=100&page=$page&fields=slug,featured_image"
        & curl.exe --fail --location --silent --show-error --max-time 60 --output $tempFile $uri
        if ($LASTEXITCODE -ne 0) { throw "Failed to retrieve WordPress posts page $page." }
        $response = [System.IO.File]::ReadAllText($tempFile, [System.Text.Encoding]::UTF8) | ConvertFrom-Json
        foreach ($post in $response.posts) { $posts.Add($post) }
    }
    finally {
        Remove-Item -LiteralPath $tempFile -Force -ErrorAction SilentlyContinue
    }
}

[System.IO.Directory]::CreateDirectory($cardDirectory) | Out-Null
$localized = 0
$preserved = 0
$withoutFeaturedImage = [System.Collections.Generic.List[string]]::new()
$failed = [System.Collections.Generic.List[string]]::new()

foreach ($post in $posts) {
    $slug = [string]$post.slug
    $slugMarker = 'Slug = "' + $slug + '",'
    $slugIndex = $source.IndexOf($slugMarker, [System.StringComparison]::Ordinal)
    if ($slugIndex -lt 0) { continue }

    $cardMatch = [regex]::Match($source.Substring($slugIndex, [Math]::Min(1200, $source.Length - $slugIndex)), 'CardImgUrl = "(?<file>[^"]+)",')
    if (-not $cardMatch.Success) { continue }

    if ($cardMatch.Groups['file'].Value -notmatch '^blog[1-5]\.png$') {
        $preserved++
        continue
    }

    $featuredImage = [string]$post.featured_image
    if ([string]::IsNullOrWhiteSpace($featuredImage)) {
        $withoutFeaturedImage.Add($slug)
        continue
    }

    $imageUri = [Uri]$featuredImage
    $extension = [System.IO.Path]::GetExtension($imageUri.AbsolutePath).ToLowerInvariant()
    if ($extension -notmatch '^\.(?:png|jpe?g|gif|webp)$') { $extension = '.jpg' }
    $safeSlug = [regex]::Replace($slug.ToLowerInvariant(), '[^a-z0-9-]', '-')
    $fileName = "legacy-$safeSlug$extension"
    $destination = Join-Path $cardDirectory $fileName

    if (-not (Test-Path -LiteralPath $destination) -or (Get-Item $destination).Length -eq 0) {
        & curl.exe --fail --location --silent --show-error --max-time 60 --output $destination $featuredImage
        if ($LASTEXITCODE -ne 0 -or -not (Test-Path -LiteralPath $destination) -or (Get-Item $destination).Length -eq 0) {
            Remove-Item -LiteralPath $destination -Force -ErrorAction SilentlyContinue
            $failed.Add("$slug | $featuredImage")
            continue
        }
    }

    $absoluteCardIndex = $slugIndex + $cardMatch.Groups['file'].Index
    $source = $source.Remove($absoluteCardIndex, $cardMatch.Groups['file'].Length).Insert($absoluteCardIndex, $fileName)
    $localized++

    if ($localized % 10 -eq 0) { Write-Output "Localized $localized card images..." }
}

[System.IO.File]::WriteAllText($sourcePath, $source, $utf8)
Write-Output "Localized card images: $localized"
Write-Output "Existing custom cards preserved: $preserved"
Write-Output "Posts without a featured image: $($withoutFeaturedImage.Count)"
Write-Output "Failed image downloads: $($failed.Count)"
if ($withoutFeaturedImage.Count -gt 0) { $withoutFeaturedImage | ForEach-Object { Write-Warning "No featured image: $_" } }
if ($failed.Count -gt 0) { $failed | ForEach-Object { Write-Warning "Download failed: $_" } }
