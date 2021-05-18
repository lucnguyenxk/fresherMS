<template>
    <div>
        <div id="header">
            <div class="name-res">
                <div class="img_list"></div>
                <select id="select-res">
                    <option value="0">CÔNG TY CỔ PHẦN MISA</option>
                    <option value="0">Nhà hàng Biển Tây</option>
                    <option value="1">Nhà hàng Biển Nam</option>
                    <option value="2">Nhà hàng Biển Bắc</option>
                </select>
            </div>
            <div class="user-in4">
                <div class="avatar"></div>
                <div class="user-name">Nguyễn Đồng Lực </div>
                <div class="cho-user"></div>
            </div>
        </div> 
    </div>
</template>
<style>
#header {
    position: absolute;
    display: flex;
    left: 180px;
    top: 0;
    right: 0;
    height: 50px;
    align-items: center;
    border-bottom: 1px solid #808080;
    justify-content: space-between;
    font-weight: bold;
}
.name-res{
    padding-left :30px;
    display : flex;
}
.img_list{
    background: url("../assets/img/Sprites.64af8f61.svg") no-repeat -847px -35px;
    width: 19px;
    height: 16px;
    margin-top: 9px;
}
.user-in4{
    display: flex;
    align-items :center;
}
#select-res{
    width: 100%;
    border-style:none ;
    border: none;
    font-weight: bold;
}
.avatar{
    padding-right:10px;
    width : 30px;
    height:30px;
    border-radius:inherit;
    background-image:url("../assets/icon/avatar-default.png");
    background-size:contain;
    background-repeat:no-repeat;
    padding-right:16px;
    cursor:pointer;
}
.cho-user{
    width: 30px;
    height: 30px;
    background-image: url("../assets/icon/option.png");
    background-repeat:no-repeat;
    background-position:center;
    padding-left:16px;
    cursor:pointer;
}


</style>