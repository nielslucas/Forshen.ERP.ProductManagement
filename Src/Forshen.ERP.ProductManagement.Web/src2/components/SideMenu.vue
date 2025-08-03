<script setup lang="ts">
import { ref } from 'vue'
import { useRoute, useRouter } from 'vue-router'

const isOpen = ref(false)
const route = useRoute()
const router = useRouter()

const menuItems = [
  { label: 'Home', icon: 'heroicons-home', to: '/' },
  { label: 'Products', icon: 'heroicons-chart-bar', to: '/products' },
]

const isActive = (to: string) => route.path === to
</script>

<template>
  <!-- Desktop sidebar -->
  <aside class="hidden md:flex flex-col w-64 border-r px-4 py-6">
    <div class="mb-6 text-xl font-semibold">My App</div>
    <nav class="flex-1 space-y-2">
      <button
          v-for="item in menuItems"
          :key="item.label"
          @click="() => router.push(item.to)"
          class="w-full text-left flex items-center gap-2 p-2 rounded transition"
          :class="[
          isActive(item.to)
            ? 'bg-gray-200 dark:bg-gray-700 font-medium'
            : 'hover:bg-gray-100 dark:hover:bg-gray-800'
        ]"
      >
        <UIcon :name="item.icon" class="w-5 h-5" />
        <span>{{ item.label }}</span>
      </button>
    </nav>
  </aside>

  <!-- Mobile header + burger -->
  <div class="md:hidden flex items-center border-b px-4 py-2">
    <UButton variant="ghost" size="sm" aria-label="Open menu" @click="isOpen = true">
      <UIcon name="heroicons-bars-3" class="w-5 h-5" />
    </UButton>
    <div class="ml-2 font-semibold">My App</div>

    <!-- Slide-over for mobile -->
    <USlideover v-model="isOpen" side="left" class="w-64">
      <div class="p-4 flex flex-col h-full">
        <div class="flex justify-between items-center mb-4">
          <h2 class="text-xl font-semibold">Menu</h2>
          <UButton variant="ghost" size="xs" @click="isOpen = false">
            <UIcon name="heroicons-x-mark" class="w-4 h-4" />
          </UButton>
        </div>
        <nav class="flex-1 space-y-2 overflow-auto">
          <button
              v-for="item in menuItems"
              :key="item.label"
              @click="() => { router.push(item.to); isOpen = false }"
              class="w-full text-left flex items-center gap-2 p-2 rounded transition"
              :class="[
              isActive(item.to)
                ? 'bg-gray-200 dark:bg-gray-700 font-medium'
                : 'hover:bg-gray-100 dark:hover:bg-gray-800'
            ]"
          >
            <UIcon :name="item.icon" class="w-5 h-5" />
            <span>{{ item.label }}</span>
          </button>
        </nav>
      </div>
    </USlideover>
  </div>
</template>
