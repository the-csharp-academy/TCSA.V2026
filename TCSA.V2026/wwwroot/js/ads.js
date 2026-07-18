window.loadAdsense = () => {
    try {
        (adsbygoogle = window.adsbygoogle || []).push({});
    } catch { }
};

window.canShowThirdCourseAd = () => {
    const desktopLayout = window.matchMedia("(min-width: 961px)").matches;
    const article = document.querySelector(".course-article-card");
    const articleHeader = article?.querySelector(".course-article-header");
    const articleContent = article?.querySelector(".course-content");
    const articleActions = article?.querySelector(".course-actions");
    const sidebar = document.querySelector(".course-sidebar");
    const adRail = document.querySelector(".course-ad-rail");

    if (!desktopLayout || !article || !articleHeader || !articleContent || !sidebar || !adRail) {
        return false;
    }

    const minimumAdHeight = 600;
    const railStyles = window.getComputedStyle(adRail);
    const adGap = Number.parseFloat(railStyles.rowGap || railStyles.gap) || 0;
    const articleContentHeight =
        articleHeader.scrollHeight +
        articleContent.scrollHeight +
        (articleActions?.scrollHeight || 0);
    const requiredSidebarHeight =
        sidebar.offsetHeight +
        adRail.scrollHeight +
        adGap +
        minimumAdHeight;

    return articleContentHeight >= requiredSidebarHeight;
};

window.canShowFourthCourseAd = () => {
    const desktopLayout = window.matchMedia("(min-width: 961px)").matches;
    const article = document.querySelector(".course-article-card");
    const articleHeader = article?.querySelector(".course-article-header");
    const articleContent = article?.querySelector(".course-content");
    const articleActions = article?.querySelector(".course-actions");
    const sidebar = document.querySelector(".course-sidebar");
    const adRail = document.querySelector(".course-ad-rail");

    if (!desktopLayout || !article || !articleHeader || !articleContent || !sidebar || !adRail) {
        return false;
    }

    const minimumAdHeight = 600;
    const railStyles = window.getComputedStyle(adRail);
    const adGap = Number.parseFloat(railStyles.rowGap || railStyles.gap) || 0;
    const articleContentHeight =
        articleHeader.scrollHeight +
        articleContent.scrollHeight +
        (articleActions?.scrollHeight || 0);
    const requiredSidebarHeight =
        sidebar.offsetHeight +
        adRail.scrollHeight +
        (adGap * 2) +
        (minimumAdHeight * 2);

    return articleContentHeight >= requiredSidebarHeight;
};

window.canShowFifthCourseAd = () => {
    const desktopLayout = window.matchMedia("(min-width: 961px)").matches;
    const article = document.querySelector(".course-article-card");
    const articleHeader = article?.querySelector(".course-article-header");
    const articleContent = article?.querySelector(".course-content");
    const articleActions = article?.querySelector(".course-actions");
    const sidebar = document.querySelector(".course-sidebar");
    const adRail = document.querySelector(".course-ad-rail");

    if (!desktopLayout || !article || !articleHeader || !articleContent || !sidebar || !adRail) {
        return false;
    }

    const minimumAdHeight = 600;
    const railStyles = window.getComputedStyle(adRail);
    const adGap = Number.parseFloat(railStyles.rowGap || railStyles.gap) || 0;
    const articleContentHeight =
        articleHeader.scrollHeight +
        articleContent.scrollHeight +
        (articleActions?.scrollHeight || 0);
    const requiredSidebarHeight =
        sidebar.offsetHeight +
        adRail.scrollHeight +
        (adGap * 3) +
        (minimumAdHeight * 3);

    return articleContentHeight >= requiredSidebarHeight;
};

window.canShowThirdArticleAd = () => {
    const desktopLayout = window.matchMedia("(min-width: 961px)").matches;
    const articleContent = document.querySelector(".article-content");
    const adRail = document.querySelector(".article-ad-rail");

    if (!desktopLayout || !articleContent || !adRail) {
        return false;
    }

    const contentStyles = window.getComputedStyle(articleContent);
    const verticalPadding =
        (Number.parseFloat(contentStyles.paddingTop) || 0) +
        (Number.parseFloat(contentStyles.paddingBottom) || 0);
    const contentBlocks = articleContent.querySelectorAll(":scope > .article-content-block");
    const intrinsicContentHeight = Array.from(contentBlocks).reduce((total, block) => {
        const blockStyles = window.getComputedStyle(block);
        const margins =
            (Number.parseFloat(blockStyles.marginTop) || 0) +
            (Number.parseFloat(blockStyles.marginBottom) || 0);

        return total + block.offsetHeight + margins;
    }, verticalPadding);

    const minimumAdHeight = 600;
    const railStyles = window.getComputedStyle(adRail);
    const adGap = Number.parseFloat(railStyles.rowGap || railStyles.gap) || 0;
    const requiredRailHeight = adRail.scrollHeight + adGap + minimumAdHeight;

    return intrinsicContentHeight >= requiredRailHeight;
};

window.canShowFourthArticleAd = () => {
    const desktopLayout = window.matchMedia("(min-width: 961px)").matches;
    const articleContent = document.querySelector(".article-content");
    const adRail = document.querySelector(".article-ad-rail");

    if (!desktopLayout || !articleContent || !adRail) {
        return false;
    }

    const contentStyles = window.getComputedStyle(articleContent);
    const verticalPadding =
        (Number.parseFloat(contentStyles.paddingTop) || 0) +
        (Number.parseFloat(contentStyles.paddingBottom) || 0);
    const contentBlocks = articleContent.querySelectorAll(":scope > .article-content-block");
    const intrinsicContentHeight = Array.from(contentBlocks).reduce((total, block) => {
        const blockStyles = window.getComputedStyle(block);
        const margins =
            (Number.parseFloat(blockStyles.marginTop) || 0) +
            (Number.parseFloat(blockStyles.marginBottom) || 0);

        return total + block.offsetHeight + margins;
    }, verticalPadding);

    const minimumAdHeight = 600;
    const railStyles = window.getComputedStyle(adRail);
    const adGap = Number.parseFloat(railStyles.rowGap || railStyles.gap) || 0;
    const requiredRailHeight = adRail.scrollHeight + (adGap * 2) + (minimumAdHeight * 2);

    return intrinsicContentHeight >= requiredRailHeight;
};

window.canShowFifthArticleAd = () => {
    const desktopLayout = window.matchMedia("(min-width: 961px)").matches;
    const articleContent = document.querySelector(".article-content");
    const adRail = document.querySelector(".article-ad-rail");

    if (!desktopLayout || !articleContent || !adRail) {
        return false;
    }

    const contentStyles = window.getComputedStyle(articleContent);
    const verticalPadding =
        (Number.parseFloat(contentStyles.paddingTop) || 0) +
        (Number.parseFloat(contentStyles.paddingBottom) || 0);
    const contentBlocks = articleContent.querySelectorAll(":scope > .article-content-block");
    const intrinsicContentHeight = Array.from(contentBlocks).reduce((total, block) => {
        const blockStyles = window.getComputedStyle(block);
        const margins =
            (Number.parseFloat(blockStyles.marginTop) || 0) +
            (Number.parseFloat(blockStyles.marginBottom) || 0);

        return total + block.offsetHeight + margins;
    }, verticalPadding);

    const minimumAdHeight = 600;
    const railStyles = window.getComputedStyle(adRail);
    const adGap = Number.parseFloat(railStyles.rowGap || railStyles.gap) || 0;
    const requiredRailHeight = adRail.scrollHeight + (adGap * 3) + (minimumAdHeight * 3);

    return intrinsicContentHeight >= requiredRailHeight;
};

window.canShowThirdProjectAd = () => {
    const desktopLayout = window.matchMedia("(min-width: 961px)").matches;
    const projectContent = document.querySelector(".project-content");
    const adRail = document.querySelector(".project-ad-rail");

    if (!desktopLayout || !projectContent || !adRail) {
        return false;
    }

    const minimumAdHeight = 600;
    const railStyles = window.getComputedStyle(adRail);
    const adGap = Number.parseFloat(railStyles.rowGap || railStyles.gap) || 0;
    const requiredRailHeight = adRail.scrollHeight + adGap + minimumAdHeight;

    return projectContent.scrollHeight >= requiredRailHeight;
};

window.canShowFourthProjectAd = () => {
    const desktopLayout = window.matchMedia("(min-width: 961px)").matches;
    const projectContent = document.querySelector(".project-content");
    const adRail = document.querySelector(".project-ad-rail");

    if (!desktopLayout || !projectContent || !adRail) {
        return false;
    }

    const minimumAdHeight = 600;
    const railStyles = window.getComputedStyle(adRail);
    const adGap = Number.parseFloat(railStyles.rowGap || railStyles.gap) || 0;
    const requiredRailHeight = adRail.scrollHeight + (adGap * 2) + (minimumAdHeight * 2);

    return projectContent.scrollHeight >= requiredRailHeight;
};
