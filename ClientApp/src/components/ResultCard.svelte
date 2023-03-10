<script lang="ts">
  import type Player from "../lib/player";

  export let player: Player;
  export let position: number;

  function getClass() {
    if (position === 1) {
      return "first";
    } else if (position === 2) {
      return "second";
    } else if (position === 3) {
      return "third";
    }
    return "";
  }
</script>

<div class="card {getClass()}">
  <div class="position">{position}</div>
  <div class="card-title">{player.name}</div>
  <div class="card-title">{player.totalSum} poäng</div>
</div>

<style>
  .card {
    display: flex;
    flex-direction: column;
    align-items: center;
    background-color: lightgrey;
    border-radius: 0.5rem;
    border: 1px solid black;
    padding: 2rem;
    margin: 1rem;
  }

  .first {
    background-color: gold;
  }

  .second {
    background-color: silver;
  }

  .third {
    background-color: sandybrown;
  }

  .position {
    font-size: 3rem;
    font-weight: bold;
  }

  .card-title {
    font-size: 1.5rem;
    font-weight: bold;
  }
</style>
