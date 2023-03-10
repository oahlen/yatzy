import type Player from "./player";

export default class Game {
    players: Player[]

    constructor(players: Player[]) {
        this.players = players;
    }

    get currentPlayer() {
        if (this.players.length === 0) {
            return null;
        }

        let player = this.players[0]

        this.players.forEach(current => {
            if (player.numberOfMarks > current.numberOfMarks) {
                player = current;
            }
        });

        return player;
    }

    get playersSorted() {
        return this.players.sort((a, b) => b.totalSum - a.totalSum);
    }

    get finished() {
        return this.players.every(x => x.finished);
    }

    getPosition(player: Player) {
        let score = player.totalSum;
        let position = 1;

        this.players.forEach(current => {
            if (player !== current) {
                if (current.totalSum > score) {
                    position++;
                }
            }
        });

        return position;
    }

    get jsonPayload() {
        let json = this.players.map(x => {
            return {
                player: x.id,
                position: this.getPosition(x),
                score: x.totalSum,
                yatzy: x.isMarked(14)
            }
        });

        return JSON.stringify(json);
    }
}
