<template>
  <q-page class="justify-evenly q-pa-md items-start q-gutter-md items-center">
    <article-container
      v-for="article in articles"
      :key="article.id"
      :article="article"
    ></article-container>

    <div class="q-pa-lg flex flex-center">
      <q-pagination
        v-model="current"
        :max="10"
        :max-pages="6"
        boundary-numbers
      />
    </div>
  </q-page>
</template>

<script lang="ts">
import ArticleContainer from 'src/components/ArticleContainer.vue';
import { defineComponent, ref } from 'vue';
import { Article } from 'components/models';

export default defineComponent({
  name: 'PageIndex',
  components: { ArticleContainer },
  setup() {
    const articles = ref<Article[]>([
      {
        id: 1,
        title: 'Test title',
        content: 'ct1',
      },
      {
        id: 2,
        title: 'Test 2',
        content: 'ct2',
      },
    ]);
    return { articles, current: ref(3) };
  },
});
</script>
