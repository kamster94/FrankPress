import { createRouter, createWebHashHistory, RouteRecordRaw } from 'vue-router';
import Home from '../views/Home.vue';
import { Auth0 } from '@/auth';

const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/categories',
    name: 'Categories',
    component: Home
  },
  {
    path: '/tags',
    name: 'Tags',
    component: Home
  },
  {
    path: '/authors',
    name: 'Authors',
    component: Home
  },
  // Admin routes
  {
    path: '/admin',
    name: 'Admin dashboard',
    component: Home
  },
  {
    path: '/admin/articles',
    name: 'Articles management',
    component: Home
  },
  {
    path: '/admin/categories',
    name: 'Categories management',
    component: Home
  },
  {
    path: '/admin/tags',
    name: 'Tags management',
    component: Home
  },
  {
    path: '/admin/media',
    name: 'Media management',
    component: Home
  },
  {
    path: '/admin/users',
    name: 'Users management',
    component: Home,
    beforeEnter: Auth0.routeGuard
  }
];

const router = createRouter({
  history: createWebHashHistory(),
  routes
});

export default router;
