window.loadAdsense = () => {
    try {
        (adsbygoogle = window.adsbygoogle || []).push({});
    } catch { }
};

window.canShowThirdCourseAd = () => {
    const desktopLayout = window.matchMedia("(min-width: 961px)").matches;
    const article = document.querySelector(".course-article-card");
    const adRail = document.querySelector(".course-ad-rail");

    if (!desktopLayout || !article || !adRail) {
        return false;
    }

    const minimumAdHeight = 600;
    const railStyles = window.getComputedStyle(adRail);
    const adGap = Number.parseFloat(railStyles.rowGap || railStyles.gap) || 0;
    const requiredRailHeight = adRail.scrollHeight + adGap + minimumAdHeight;

    return article.offsetHeight >= requiredRailHeight;
};
