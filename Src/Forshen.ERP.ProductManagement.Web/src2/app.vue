<script setup lang="ts">
import SideMenu from '~/components/SideMenu.vue'
</script>

<style>
@import "tailwindcss";
@import "@nuxt/ui";
</style>

<template>
  <UApp>
    <div
        style="display: flex; height: 100vh; width: 100vw; overflow: hidden;"
    >
      <!-- Sidebar -->
      <SideMenu/>

      <!-- Content -->
      <main
          style="
          flex: 1 1 auto;
          display: flex;
          justify-content: center;
          /*align-items: center;*/
          padding: 2rem;
          overflow-y: auto;
        "
      >
        <NuxtPage />
      </main>
    </div>
  </UApp>
</template>
