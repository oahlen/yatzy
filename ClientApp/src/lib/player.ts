export default class Player {
    id: number;
    name: string;
    #scores: number[];
    #marks: boolean[];

    constructor(id: number, name: string) {
        this.id = id;
        this.name = name;
        this.#scores = Array(15).fill(0)
        this.#marks = Array(15).fill(false);
    }

    get sum() {
        return this.#scores.slice(0, 6).reduce((a, b) => a + b);
    }

    get bonus() {
        return this.sum >= 63 ? 50 : 0;
    }

    get totalSum() {
        return this.#scores.reduce((a, b) => a + b) + this.bonus;
    }

    get yatzy() {
        return this.#scores[this.#scores.length - 1] > 0;
    }

    get finished() {
        return this.#marks.every(mark => mark);
    }

    get numberOfMarks() {
        return this.#marks.filter(x => x).length;
    }

    isMarked(index: number) {
        return this.#marks[index];
    }

    setScore(value: number, index: number) {
        this.#scores[index] = value;
        this.#marks[index] = true;
    }

    resetScore(index: number) {
        this.#scores[index] = 0;
        this.#marks[index] = false;
    }

    getScore(index: number) {
        return this.#marks[index] ? this.#scores[index] : -1;
    }

    getScoreString(index: number) {
        return this.#marks[index] ? this.#scores[index].toString() : "";
    }

    getDeltaString(index: number) {
        if (!this.#marks[index]) {
            return "";
        }

        let delta = this.#scores[index] - 3 * (index + 1);
        return delta === 0 ? "" : delta.toString();
    }

    getDeltaLabel(index: number) {
        return this.#scores[index] - 3 * (index + 1) < 0 ? "negative" : "positive";
    }

    getTotalDelta() {
        let total = 0;
        let expected = 0;

        for (let i = 0; i < 6; i++) {
            if (this.#marks[i]) {
                total += this.#scores[i];
                expected += (i + 1) * 3;
            }
        }

        return total - expected;
    }

    getTotalDeltaString() {
        var delta = this.getTotalDelta();
        return delta === 0 ? "" : delta.toString();
    }

    getTotalDeltaLabel() {
        return this.getTotalDelta() < 0 ? "negative" : "positive";
    }

    getBonusString() {
        let bonus = this.bonus;
        return bonus > 0 || this.#marks.slice(0, 6).every(mark => mark) ? bonus.toString() : "";
    }
}

