export function scrollToAnchor(anchorId) {
    if (!anchorId) return;

    const element = document.getElementById(anchorId);
    if (!element) return;

    element.scrollIntoView({ behavior: 'smooth', block: 'end' });

    element.classList.add('search-highlight');
    setTimeout(() => {
        if (document.body.contains(element)) {
            element.classList.remove('search-highlight');
        }
    }, 2000);
}