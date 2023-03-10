import Dashboard from './pages/Dashboard.svelte'
import Game from './pages/Game.svelte'
import NotFound from './pages/NotFound.svelte'

export const routes = {
    '/': Dashboard,
    '/game/': Game,
    '*': NotFound
}
