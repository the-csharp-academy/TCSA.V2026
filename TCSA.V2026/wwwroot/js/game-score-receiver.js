const receivers = new Map();

export function start(frame, gameId, gameOrigin, receiver) {
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
            !Number.isSafeInteger(message.score) || message.score < 0 ||
            message.score > 2147483647) {
            return;
        }

        console.info("Game score received:", {
            gameId: message.gameId,
            score: message.score
        });

        receiver.invokeMethodAsync("ReceiveScore", gameId, message.score)
            .catch((error) => {
                console.error("Could not deliver game score to the academy:", error);
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
