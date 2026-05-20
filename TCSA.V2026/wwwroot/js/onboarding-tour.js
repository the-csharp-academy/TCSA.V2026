import Shepherd from "https://cdn.jsdelivr.net/npm/shepherd.js@15.2.2/dist/js/shepherd.mjs";

export class OnboardingTour {
    constructor() {
        this._tour = null;
    }

    startTour(dotNetRef) {

        this._cancel();
        this._expandDashboardGroup();

        this._tour = new Shepherd.Tour({
            useModalOverlay: true,
            defaultStepOptions: {
                scrollTo: true,
                cancelIcon: { enabled: true }
            }
        });

        const steps = [
            {
                id: 'nav-gallery',
                title: 'Gallery',
                text: 'Showcase your completed projects to the public and browse what other students have built.'
            },
            {
                id: 'nav-community-feed',
                title: 'Community Feed',
                text: 'See the latest achievements and project completions from students across the platform.'
            },
            {
                id: 'nav-articles',
                title: 'Articles',
                text: 'Technical articles written by the platform team - tips, deep dives, and how-tos.'
            },
            {
                id: 'nav-blog',
                title: 'Blog',
                text: 'Posts written by the platform team - news, updates, and insights about the community.'
            },
            {
                id: 'nav-dashboard-group',
                title: 'Dashboard',
                text: 'Your personal learning hub - everything related to your progress lives here.'
            },
            {
                id: 'nav-overview',
                title: 'Overview',
                text: 'The full grid of curriculum areas - choose a project, and start building.'
            },
            {
                id: 'nav-profile',
                title: 'Profile',
                text: 'Set your GitHub, Discord, and CodeWars usernames to unlock platform features.'
            },
            {
                id: 'nav-roadmap',
                title: 'Roadmap',
                text: 'The full belt progression - see what projects you need to complete to earn the next belt.'
            },
            {
                id: 'nav-leaderboard',
                title: 'Leaderboard',
                text: 'See how you rank among all students on the platform.'
            },
            {
                id: 'nav-activity',
                title: 'Activity',
                text: 'Your full history of submissions, reviews, and XP earned over time.'
            },
            {
                id: 'nav-community',
                title: 'Community',
                text: 'Find, take, and submit issues for The C# Academy and other open source projects - contribute to real codebases and earn XP.'
            },
            {
                id: 'nav-peer-reviews',
                title: 'Peer Reviews',
                text: 'Review submitted code once you reach Yellow belt - earn XP for every review.'
            },
            {
                id: 'nav-courses',
                title: 'Courses',
                text: 'Text-based courses on a range of topics - read through lessons and deepen your understanding.'
            },
            {
                id: 'nav-challenges',
                title: 'Challenges',
                text: 'Daily coding challenges to sharpen your skills and earn XP.'
            },
            {
                id: 'nav-vip',
                title: 'VIP Membership',
                text: 'Premium membership with extra resources, priority support, and exclusive content.'
            },
            {
                id: 'nav-coffee',
                title: 'Buy Us A Coffee',
                text: 'The platform is free and community-run — every contribution helps keep it going.'
            }
        ];

        steps.forEach((step, index) => {
            const isLast = index === steps.length - 1;
            const content = document.createElement('span');
            content.className = 'mud-primary-text';
            content.innerHTML = step.text;
            
            this._tour.addStep({
                attachTo: { element: `#${step.id}`, on: 'right' },
                title: `<span class="mud-primary-text" style="font-weight:bold">${step.title}</span>`,
                text: content,
                buttons: isLast
                    ? [{ text: 'Finish', action: this._tour.complete, classes: 'mud-button-filled mud-button-filled-primary' }]
                    : [{ text: 'Next', action: this._tour.next, classes: 'mud-button-filled mud-button-filled-primary' }]
            });
        });

        this._tour.on('complete', () => dotNetRef.invokeMethodAsync('CompleteTour'));
        this._tour.on('cancel', () => dotNetRef.invokeMethodAsync('CompleteTour'));

        this._tour.start();
    }

    _cancel() {
        this._tour?.cancel();
        this._tour = null;
    }

    _expandDashboardGroup() {
        const group = document.querySelector('#nav-dashboard-group');
        const button = group?.querySelector('button');
        if (button?.getAttribute('aria-expanded') === 'false') {
            button.click();
        }
    }
}

export function initOnboarding() {
    return new OnboardingTour();
}
