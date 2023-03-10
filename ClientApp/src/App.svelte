<script lang="ts">
  import NavBar from "./components/NavBar.svelte";
  import Router from "svelte-spa-router";
  import { routes } from "./routes";
</script>

<main>
  <NavBar />
  <div class="content">
    <Router {routes} />
  </div>
</main>

<style>
  .content {
    margin: 1rem;
  }
</style>
