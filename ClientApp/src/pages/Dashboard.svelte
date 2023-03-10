<script lang="ts">
  import { onMount } from "svelte";

  let highscores = [];

  function winPercentage(highscore: any) {
    return Math.trunc((highscore.wins / highscore.games) * 100);
  }

  function yatzyPercentage(highscore: any) {
    return Math.trunc((highscore.yatzy / highscore.games) * 100);
  }

  onMount(async () => {
    fetch("Highscore")
      .then((response) => response.json())
      .then((data) => (highscores = data));
  });
</script>

<div class="content">
  <h1>Spelarstatistik</h1>

  <table>
    <tr>
      <th>Spelare</th>
      <th>Vinster</th>
      <th>Förluster</th>
      <th>Andel vinster %</th>
      <th>Rekord</th>
      <th>Antal yatzy</th>
      <th>Andel yatzy %</th>
    </tr>
    {#each highscores as highscore, _}
      <tr>
        <td>{highscore.playerName}</td>
        <td>{highscore.wins}</td>
        <td>{highscore.losses}</td>
        <td>{winPercentage(highscore)}</td>
        <td>{highscore.record}</td>
        <td>{highscore.yatzy}</td>
        <td>{yatzyPercentage(highscore)}</td>
      </tr>
    {/each}
  </table>
</div>

<style>
  .content {
    display: flex;
    flex-direction: column;
    align-items: center;
    margin-left: 10%;
    margin-right: 10%;
  }

  table {
    width: 100%;
    border-collapse: collapse;
  }

  th {
    background-color: #ffffc0;
    border: 1px solid black;
    text-align: left;
    padding: 0.5rem;
    font-size: 1.5rem;
  }

  td {
    font-size: 1.5rem;
    border: 1px solid black;
    padding: 0.5rem;
  }

  tr:nth-child(even) {
    background-color: #f0f0f0;
  }
</style>
