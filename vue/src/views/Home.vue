<template>
  <div class="home">
    <img alt="Vue logo" src="../assets/logo.png" />
    <article-box
      v-for="article in articles"
      :key="article.id"
      :article="article"
    />
  </div>
</template>

<script lang="ts">
import { Options, Vue } from 'vue-class-component';
import HelloWorld from '@/components/HelloWorld.vue'; // @ is an alias to /src
import ArticleBox from '@/components/ArticleBox.vue';
import { Article } from '@/models';

@Options({
  components: {
    HelloWorld,
    ArticleBox
  },
  data() {
    const articles: Article[] = [
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
    ];
    return {
      articles
    };
  }
})
export default class Home extends Vue {}
</script>
