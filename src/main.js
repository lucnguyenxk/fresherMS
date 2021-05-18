import Vue from 'vue'
import App from './App.vue'
import VueRouter from 'vue-router'
import VuePaginate from 'vue-paginate'
import VueMask from 'v-mask'
import money from 'v-money'
import axios from 'axios'
import VueAxios from 'vue-axios'

Vue.config.productionTip = false;
import CustomerList from './view/customer/customerList.vue';
import Report from './view/report/report.vue'
const routes = [
    {path :'/customerList', component:CustomerList},
    {path : '/report', component:Report},
]
const router = new VueRouter({
  routes
})
Vue.use(VueAxios, axios);
Vue.use(money);
Vue.use(VueMask);
Vue.use(VuePaginate);
Vue.use(VueRouter);
new Vue({
  router,
  render: h => h(App),
}).$mount('#app')
