export function scrollToAnchor(anchorId, highlightTerms) {
    if (!anchorId) return;

    const element = document.getElementById(anchorId);
    if (!element) return;

    element.scrollIntoView({ behavior: 'smooth', block: 'end' });

    if (!highlightTerms || highlightTerms.length === 0) return;

    const originalText = element.textContent;
    const escaped = highlightTerms.map(t => t.replace(/[.*+?^${}()|[\]\\]/g, '\\$&'));
    const regex = new RegExp(`(${escaped.join('|')})`, 'gi');
    element.innerHTML = originalText.replace(regex, '<mark>$1</mark>');

    setTimeout(() => {
        element.textContent = originalText;
    }, 2000);
}