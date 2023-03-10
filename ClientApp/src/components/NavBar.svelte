<script lang="ts">
  import { link } from "svelte-spa-router";
  import HomeIcon from "../assets/HomeIcon.svelte";
  import PlusIcon from "../assets/PlusIcon.svelte";
</script>

<div class="header">
  <a href="/" use:link><HomeIcon /></a>
  <div class="title">Yatzy</div>
  <a href="/game/" use:link><PlusIcon /></a>
</div>

<style>
  .header {
    display: flex;
    background-color: #ffffe0;
    border-bottom: 1px solid black;
    align-items: center;
    justify-content: space-between;
    padding: 0.5rem 1rem 0.5rem 1rem;
  }

  a {
    padding: 0.25rem;
  }

  a:hover {
    border-radius: 0.25rem;
    background-color: rgba(0, 0, 0, 0.2);
  }

  a:active {
    background-color: rgba(0, 0, 0, 0.3);
  }

  .title {
    font-size: 2rem;
    font-weight: bold;
  }
</style>
