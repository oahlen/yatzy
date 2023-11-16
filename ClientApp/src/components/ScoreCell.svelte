<script lang="ts">
  import { createEventDispatcher } from "svelte";
  import type Player from "../lib/player";

  export let player: Player;
  export let index: number;
  export let style: string;
  export let bonus = false;

  const dispatch = createEventDispatcher();

  function click() {
    dispatch("clicked", {
      player: player,
      index: index,
    });
  }
</script>

<!-- svelte-ignore a11y-click-events-have-key-events -->
{#if bonus}
  <!-- svelte-ignore a11y-no-static-element-interactions -->
  <div class="grid-item cell detail {style}" on:click={click}>
    <span />
    <span class="center">{player.getScoreString(index)}</span>
    <span class="right {player.getDeltaLabel(index)}"
      >{player.getDeltaString(index)}</span
    >
  </div>
{:else}
  <!-- svelte-ignore a11y-no-static-element-interactions -->
  <div class="grid-item cell {style}" on:click={click}>
    {player.getScoreString(index)}
  </div>
{/if}

<style>
  .grid-item {
    height: 2rem;
    line-height: 2rem;
    padding: 0.25rem 0rem;
  }

  .grid-item.cell {
    font-size: 1.5rem;
    text-align: center;
    border: black 1px solid;
    cursor: default;
  }

  .detail {
    display: grid;
    grid-template-columns: repeat(3, minmax(0, 1fr));
  }

  .right {
    margin-left: auto;
    margin-right: 0.5rem;
  }

  .right.positive {
    color: darkgreen;
  }

  .right.negative {
    color: darkred;
  }

  .current {
    background-color: #ffffc0;
  }
</style>
