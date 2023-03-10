<script lang="ts">
  import { createEventDispatcher } from "svelte";
  import type Game from "../lib/game";
  import ResultCard from "./ResultCard.svelte";

  const dispatch = createEventDispatcher();

  export let game: Game;

  function close() {
    dispatch("closed", {});
  }
</script>

<div class="dialog">
  <div class="dialog-content">
    <span class="header">Resultat</span>

    <div class="content">
      {#each game.playersSorted as player, _}
        <ResultCard {player} position={game.getPosition(player)} />
      {/each}
    </div>

    <button class="dialog-button" on:click={close}>Spela igen</button>
  </div>
</div>

<style>
  .dialog {
    background-color: rgba(0, 0, 0, 0.75);
    position: fixed;
    z-index: 1;
    left: 0;
    top: 0;
    width: 100%;
    height: 100%;
  }

  .dialog-content {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: space-between;
    background-color: white;
    border-radius: 1rem;
    position: fixed;
    top: 25%;
    left: 25%;
    width: 50%;
    height: 50%;
    padding: 1rem;
  }

  .header {
    font-size: 2rem;
    font-weight: bold;
  }

  .content {
    display: flex;
    justify-content: space-evenly;
  }

  .dialog-button {
    background-color: green;
    color: white;
    padding: 1rem;
    border-radius: 0.5rem;
    border: none;
    font-size: 1.5rem;
  }
</style>
