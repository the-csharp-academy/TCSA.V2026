const receivers = new Map();

export function start(frame, gameId, gameOrigin) {
    stop(frame);

    const receiveScore = (event) => {
        if (event.origin !== gameOrigin ||
            event.source !== frame.contentWindow) {
            return;
        }

        const message = event.data;

        if (message === null || typeof message !== "object" ||
            message.type !== "academy:game-score" ||
            message.gameId !== gameId ||
            !Number.isSafeInteger(message.score) || message.score < 0) {
            return;
        }

        console.info("Game score received:", {
            gameId: message.gameId,
            score: message.score
        });
    };

    window.addEventListener("message", receiveScore);
    receivers.set(frame, receiveScore);
}

export function stop(frame) {
    const receiveScore = receivers.get(frame);

    if (receiveScore) {
        window.removeEventListener("message", receiveScore);
        receivers.delete(frame);
    }
}
