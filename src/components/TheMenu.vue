<template>
    <div>
        <div class="menu">
            <div class="menu-top">
                <div class="img-list"></div>
                <div class="img-logo "></div>
                <div class=" TextMenuCus">Kế Toán</div>
            </div>
            <div class="menu-list">
                <div class="item">
                    <div class="image-icon dashboard "></div>
                    <div class="menu-text ">Tổng quan</div>
                </div>
               <router-link class="item" to ='/report'>
                    <div class="image-icon report "></div>
                    <div class="menu-text ">Báo cáo</div>
                </router-link>
                <div class="item">
                    <div class="image-icon dashboard"></div>
                    <div class="menu-text ">Mua hàng</div>
                </div>
               <router-link class="item" to='/customerList'>
                    <div class="image-icon employee"></div>
                    <div class="menu-text ">Nhân viên</div>
                </router-link>
                <div class="item">
                    <div class="image-icon setting"></div>
                    <div class="menu-text ">Cài đặt</div>
                </div>
            </div>
        </div>
    </div>
</template>
<style>
@import '../style/menu.css'
</style>