<script lang="ts">
  import Grid from "../components/Grid.svelte";
  import ResultDialog from "../components/ResultDialog.svelte";
  import Player from "../lib/player";
  import Game from "../lib/game";

  let players: any[];
  let game: Game;

  let showResult = false;

  async function fetchPlayers() {
    const response = await fetch("Player");
    players = await response.json();
    game = new Game(players.map((x: any) => new Player(x.id, x.name)));
  }

  function newGame() {
    showResult = false;
    game = new Game(players.map((x: any) => new Player(x.id, x.name)));
  }

  function finishGame(event: any) {
    postResult(event.detail.game.jsonPayload)
      .then((_) => {})
      .catch((error) => {
        console.error("Error:", error);
      })
      .finally(() => {
        showResult = true;
      });
  }

  async function postResult(payload: string) {
    const response = await fetch("Result", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: payload,
    });
    return response;
  }
</script>

{#await fetchPlayers() then _}
  {#if showResult}
    <ResultDialog {game} on:closed={newGame} />
  {/if}

  <Grid {game} on:finished={(event) => finishGame(event)} />
{/await}
