window.tcsaAnalytics = {
    trackPageView: function (url, title) {
        if (typeof window.gtag !== "function") {
            console.warn("Google Analytics is not loaded.");
            return;
        }

        const parsedUrl = new URL(url);

        window.gtag("event", "page_view", {
            page_title: title || document.title,
            page_location: parsedUrl.href,
            page_path: parsedUrl.pathname + parsedUrl.search
        });
    }
};
