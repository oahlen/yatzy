<script lang="ts">
  import { createEventDispatcher } from "svelte";
  import NumPadDialog from "./NumPadDialog.svelte";
  import ScoreCell from "./ScoreCell.svelte";
  import type Game from "../lib/game";
  import type Player from "../lib/player";
  import { headers } from "../lib/headers";

  const dispatch = createEventDispatcher();

  export let game: Game;

  let selectedPlayer: Player;
  let currentIndex = -1;

  let dialogVisible = false;

  function containerStyle() {
    return `grid-template-columns: auto repeat(${game.players.length.toString()}, 1fr)`;
  }

  function cellStyle(player: Player) {
    return game.currentPlayer === player ? "current" : "";
  }

  function onClicked(event: any) {
    selectedPlayer = event.detail.player;
    currentIndex = event.detail.index;
    dialogVisible = true;
  }

  function closeDialog() {
    dialogVisible = false;
    game.players = game.players;

    if (game.finished) {
      dispatch("finished", { game: game });
    }
  }
</script>

{#if dialogVisible}
  <NumPadDialog
    player={selectedPlayer}
    index={currentIndex}
    on:closed={closeDialog}
  />
{/if}

<div class="grid-container" style={containerStyle()}>
  <div class="grid-item header margin strong">Spelare</div>

  {#each Array(6) as _, index (index)}
    <div class="grid-item">{headers[index]}</div>
  {/each}

  <div class="grid-item margin strong">Summma</div>
  <div class="grid-item margin strong">Bonus</div>

  {#each Array(headers.length - 6) as _, index (index)}
    <div class="grid-item">{headers[index + 6]}</div>
  {/each}

  <div class="grid-item margin strong"><span>Total summa</span></div>
  <div class="grid-item margin strong">Placering</div>

  {#each game.players as player}
    <div class="grid-item header player">{player.name}</div>

    {#each Array(6) as _, index (index)}
      <ScoreCell
        {player}
        {index}
        bonus={true}
        style={cellStyle(player)}
        on:clicked={(event) => onClicked(event)}
      />
    {/each}

    <!-- svelte-ignore a11y-no-static-element-interactions -->
    <div class="grid-item cell detail highlight {cellStyle(player)}">
      <span />
      <span class="center">{player.sum}</span>
      <span class="right {player.getTotalDeltaLabel()}"
        >{player.getTotalDeltaString()}</span
      >
    </div>

    <div class="grid-item cell highlight {cellStyle(player)}">
      {player.getBonusString()}
    </div>

    {#each Array(headers.length - 6) as _, index (index)}
      <ScoreCell
        {player}
        index={index + 6}
        style={cellStyle(player)}
        on:clicked={(event) => onClicked(event)}
      />
    {/each}

    <div class="grid-item cell highlight {cellStyle(player)}">
      {player.totalSum}
    </div>
    <div class="grid-item cell highlight {cellStyle(player)}">
      {game.getPosition(player)}
    </div>
  {/each}
</div>

<style>
  .grid-container {
    display: grid;
    grid-template-rows: repeat(20, auto);
    grid-auto-flow: column;
    font-size: 1.5rem;
    align-items: stretch;
  }

  .grid-item {
    height: 2rem;
    line-height: 2rem;
    padding: 0.25rem 0rem;
  }

  .grid-item.header {
    margin-bottom: 1rem;
  }

  .grid-item.margin {
    text-align: left;
    margin-right: 1rem;
  }

  .grid-item.player {
    text-align: center;
  }

  .grid-item.cell {
    font-size: 1.5rem;
    text-align: center;
    border: black 1px solid;
    cursor: default;
  }

  .grid-item.strong {
    font-weight: bold;
  }

  .grid-item.highlight {
    background-color: lightgrey;
  }

  .grid-item.highlight.current {
    background-color: #ffff00;
  }

  /* TODO Break out duplicated styles */
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
</style>
