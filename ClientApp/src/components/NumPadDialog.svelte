<script lang="ts">
  import { createEventDispatcher } from "svelte";
  import type Player from "../lib/player";
  import { headers } from "../lib/headers";

  const dispatch = createEventDispatcher();

  export let player: Player;
  export let index: number;
  let value = "";

  function click(input: number) {
    if (value.length == 0 && (input == 0 || input > 5)) {
      player.setScore(input, index);
      close();
      return;
    }
    value += input.toString();

    if (value.length >= 2) {
      player.setScore(parseInt(value, 10), index);
      close();
    }
  }

  function done() {
    if (value.length > 0) {
      player.setScore(parseInt(value, 10), index);
    } else {
      player.resetScore(index);
    }
    close();
  }

  function reset() {
    value = "";
  }

  function cancel() {
    close();
  }

  function close() {
    dispatch("closed", {});
  }
</script>

<div class="dialog">
  <div class="dialog-content">
    <div class="input-grid">
      <div class="dialog-title" style="grid-area: player;">
        {player.name}
      </div>
      <div class="dialog-title" style="grid-area: value; text-align: center">
        {value}
      </div>
      <div class="dialog-title" style="grid-area: type; text-align: right">
        {headers[index]}
      </div>

      <button
        class="dialog-button"
        style="grid-area: one;"
        on:click={() => click(1)}>1</button
      >
      <button
        class="dialog-button"
        style="grid-area: two;"
        on:click={() => click(2)}>2</button
      >
      <button
        class="dialog-button"
        style="grid-area: three;"
        on:click={() => click(3)}>3</button
      >
      <button
        class="dialog-button"
        style="grid-area: four;"
        on:click={() => click(4)}>4</button
      >
      <button
        class="dialog-button"
        style="grid-area: five;"
        on:click={() => click(5)}>5</button
      >
      <button
        class="dialog-button"
        style="grid-area: six;"
        on:click={() => click(6)}>6</button
      >
      <button
        class="dialog-button"
        style="grid-area: seven;"
        on:click={() => click(7)}>7</button
      >
      <button
        class="dialog-button"
        style="grid-area: eight;"
        on:click={() => click(8)}>8</button
      >
      <button
        class="dialog-button"
        style="grid-area: nine;"
        on:click={() => click(9)}>9</button
      >
      <button
        class="dialog-button zero"
        style="grid-area: zero;"
        on:click={() => click(0)}>0</button
      >

      <button class="dialog-button ok" on:click={done}>Klar</button>
      <button class="dialog-button reset" on:click={reset}> Rensa </button>
      <button class="dialog-button cancel" on:click={cancel}>Avbryt</button>
    </div>
  </div>
</div>

<style>
  .dialog {
    position: fixed;
    z-index: 1;
    left: 0;
    top: 0;
    width: 100%;
    height: 100%;
  }

  .dialog-content {
    position: fixed;
    background-color: rgba(0, 0, 0, 0.75);
    bottom: 0;
    width: 100%;
  }

  .input-grid {
    display: grid;
    margin: 2rem;
    grid-template-columns: 1fr 1fr 1fr;
    grid-template-areas:
      "player value type"
      "one two three"
      "four five six"
      "seven eight nine"
      ". zero ."
      "ok clear cancel";
    column-gap: 1rem;
    row-gap: 1rem;
  }

  .dialog-title {
    font-size: 2rem;
    color: white;
  }

  .dialog-button {
    color: black;
    height: 4rem;
    border-radius: 0.5rem;
    border: none;
    font-size: 1.5rem;
  }

  .dialog-button.zero {
    margin-bottom: 3rem;
  }

  .dialog-button.ok {
    grid-area: ok;
    color: white;
    background-color: green;
  }

  .dialog-button.reset {
    grid-area: clear;
    display: flex;
    align-items: center;
    justify-content: center;
  }

  .dialog-button.cancel {
    grid-area: cancel;
    color: white;
    background-color: red;
  }
</style>
