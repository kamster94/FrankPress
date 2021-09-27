<template>
  <q-page class="justify-evenly q-pa-md items-start q-gutter-md items-center">
    <article-box
      v-for="article in articles"
      :key="article.id"
      :article="article"
    />
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
import ArticleBox from '@/components/ArticleBox.vue';
import { Article } from '@/models';
import { ref, defineComponent } from 'vue';

export default defineComponent({
  name: 'Home',
  components: {
    ArticleBox
  },
  setup() {
    const articles = ref<Article[]>([
      {
        Id: 1,
        Title: 'Test title',
        Content: 'ct1'
      },
      {
        Id: 2,
        Title: 'Test 2',
        Content: 'ct2'
      }
    ]);
    return { articles, current: ref(3) };
  }
});
</script>
