window.mentorshipScroll = {
    scrollToSubscribe: function() {
        const section = document.querySelector('.subscription-section');
        if (section) {
            section.scrollIntoView({ behavior: 'smooth', block: 'start' });
        }
    }
};
