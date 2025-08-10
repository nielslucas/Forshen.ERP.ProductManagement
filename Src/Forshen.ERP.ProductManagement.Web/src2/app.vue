<script setup lang="ts">
import { ref } from 'vue'
import { useRoute, useRouter } from 'vue-router'

const route = useRoute()

const leftDrawerOpen = ref(false);
function toggleLeftDrawer() {
  leftDrawerOpen.value = !leftDrawerOpen.value
}

function isActive(menuItem: MenuItem) {
  return route.path === menuItem.to
}

interface MenuItem {
  icon: string
  label: string
  to: string
  separator?: boolean
}

const menuList: MenuItem[] = [
  {
    icon: 'inbox',
    label: 'Inbox',
    to: '/',
    separator: true,
  },
  {
    icon: 'send',
    label: 'Outbox',
    to: '/products',
    separator: false,
  },
  // {
  //   icon: 'delete',
  //   label: 'Trash',
  //   to: '/',
  //   separator: false
  // },
  // {
  //   icon: 'error',
  //   label: 'Spam',
  //   to: '/',
  //   separator: true
  // },
  // {
  //   icon: 'settings',
  //   label: 'Settings',
  //   to: '/',
  //   separator: false
  // },
  // {
  //   icon: 'feedback',
  //   label: 'Send Feedback',
  //   to: '/',
  //   separator: false
  // },
  // {
  //   icon: 'help',
  //   iconColor: 'primary',
  //   label: 'Help',
  //   to: '/',
  //   separator: false
  // }
]

</script>

<template>
  <q-layout view="hHh lpR fFf">

    <q-header reveal elevated class="bg-primary text-white">
      <q-toolbar>
        <q-btn dense flat round icon="menu" @click="toggleLeftDrawer" />

        <q-toolbar-title>
          <q-avatar>
            <img src="https://cdn.quasar.dev/logo-v2/svg/logo-mono-white.svg">
          </q-avatar>
          Title
        </q-toolbar-title>
      </q-toolbar>
    </q-header>

    <!--    <q-drawer show-if-above v-model="leftDrawerOpen" side="left" bordered>-->
    <!--      &lt;!&ndash; drawer content &ndash;&gt;-->
    <!--    </q-drawer>-->

    <q-drawer
        v-model="leftDrawerOpen"
        show-if-above
        :width="200"
        :breakpoint="500"
        bordered
        :class="$q.dark.isActive ? 'bg-grey-9' : 'bg-grey-3'"
    >
      <q-scroll-area class="fit">
        <q-list>

          <template v-for="(menuItem, index) in menuList" :key="index">
            <q-item clickable
                    :active="isActive(menuItem)"
                    v-ripple
                    :to="menuItem.to">
              <q-item-section avatar>
                <q-icon :name="menuItem.icon" />
              </q-item-section>
              <q-item-section>
                {{ menuItem.label }}
              </q-item-section>
            </q-item>
            <q-separator :key="'sep' + index"  v-if="menuItem.separator" />
          </template>

        </q-list>
      </q-scroll-area>
    </q-drawer>

    <q-page-container>
      <q-page padding>
        <NuxtPage />
      </q-page>
    </q-page-container>

  </q-layout>
</template>
