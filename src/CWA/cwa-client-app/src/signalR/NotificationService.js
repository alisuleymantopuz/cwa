import messageHubService from './MessageHubController';

export default class NotificationService {
    constructor(messageReceived) {
        this._messageReceived = messageReceived;

        messageHubService.registerReceiveEvent((msg) => {
            this._messageReceived(msg);
        });
    }

    sendMessage = (message) => {
        messageHubService.sendMessage(message);
    }
}
