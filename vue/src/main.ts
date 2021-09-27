import { createApp } from 'vue';
import App from '@/App.vue';
import { Auth0 } from '@/auth';
import router from '@/router';
import store from '@/store';
import { Quasar } from 'quasar';
import quasarUserOptions from './quasar-user-options';

async function initApp() {
  const AuthPlugin = await Auth0.init({
    onRedirectCallback: (appState) => {
      router.push(
        appState && appState.targetUrl
          ? appState.targetUrl
          : window.location.pathname
      );
    },
    clientId: process.env.VUE_APP_AUTH0_CLIENT_KEY ?? '',
    domain: process.env.VUE_APP_AUTH0_DOMAIN ?? '',
    audience: process.env.VUE_APP_AUTH0_AUDIENCE ?? '',
    redirectUri: window.location.origin
  });
  const app = createApp(App);
  app
    .use(AuthPlugin)
    .use(store)
    .use(router)
    .use(Quasar, quasarUserOptions)
    .mount('#app');
}

initApp();
