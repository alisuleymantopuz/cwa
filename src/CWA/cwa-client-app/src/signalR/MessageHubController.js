import { HubConnectionBuilder, LogLevel } from "@aspnet/signalr"

class MessageHubController {
    constructor(props) {
        this.rConnection = new HubConnectionBuilder()
            .withUrl("http://localhost:5000/messageHub")
            .configureLogging(LogLevel.Information)
            .build();

        this.rConnection.start()
            .catch(err => {
                console.log('connection error!');
            });
    }


    registerReceiveEvent = (callback) => {
        this.rConnection.on("ReceiveMessage", function (message) {
            console.log(message);
            callback(message);
        });
    }

    sendMessage = (message) => {
        return this.rConnection.invoke("SendMessage", message)
            .catch(function (data) {
                console.log(data);
            });
    }
}

const messageHubService = new MessageHubController();
export default messageHubService;