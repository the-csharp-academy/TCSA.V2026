export function scrollToAnchor(anchorId) {
    if (!anchorId) return;

    const element = document.getElementById(anchorId);
    if (element) {
        element.scrollIntoView({ behavior: 'smooth' });
    }
}