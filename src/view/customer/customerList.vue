<template>
    <div>
        <div class=" page-title">
                <div class="page-left "> Nhân viên </div>
                <div class="page-right ">
                    <button class="btn-default" id="btn-add">
                        <div class="icon-add"></div>
                        <div id="text-btn-add" class="text-btn-add" @click="addCusOnClick()">Thêm khách hàng</div>
                    </button>
                </div>
            </div>
            <div  class="listEmployee">
            <div class=" toolbar">
                <input type="text" name="name" value="" class="input-search" placeholder="tìm kiếm theo mã, tên khách hàng" ref="search" v-model="stringInput" @keyup="InputSearchString(stringInput)"/>
                <button class="btn-refresh" @click="RefreshOnClick()"></button>
            </div>
            
            <div class="grid">
               <table id="tbListCustomer" class="table" width =100% >
                    <thead>
                        <tr>
                            <th>MÃ NHÂN VIÊN</th>
                            <th>HỌ TÊN</th>
                            <th class="colum-BankCount">GIỚI TÍNH</th>
                            <th class="colum-DOB">NGÀY SINH</th>
                            <th>ĐiỆN THOẠI</th>
                            <th class="colum-Email">EMAIL</th>
                            <th>CHỨC VỤ</th>
                            <th>PHÒNG BAN</th>
                            <th class="colum-BankCount"> STK NGÂN HÀNG</th>
                            <th class="colum-fixed">CHỨC NĂNG</th>
                        </tr>
                    </thead>
                    <tbody>
                            <tr v-for="emp in this.employees" :key="emp.employeeId"  @click="TakeIdDel(emp.EmployeeId)" >
                                <td>{{emp.employeeCode}}</td>
                                <td>{{emp.fullname}}</td>
                                <td class="colum-BankCount">{{formatGender(emp.gender)}}</td>
                                <td>{{formatDate(emp.dateOfBirth)}}</td>
                                <td>{{emp.phoneNumber}}</td>
                                <td>{{emp.email}}</td>
                                <td>{{emp.position}}</td>
                                <td>{{emp.departmentName}}</td>
                                <td class="colum-BankCount" >{{emp.bankAccountNumber}}</td>
                                <td class="funtion colum-fixed">
    
                                <div class="updateEmp">
                                    <button class = "update Employee" @click="empOnClick(emp.employeeId)">Sửa</button>
                                </div>
                                <div class="listFuncEmp">
                                    <button class="listFunc Employee" @click="listFuncOnClick(emp.employeeId,emp.employeeCode)"></button>
                                    <ListFunction
                                        :isShow="isShowListFunction && currentId == emp.employeeId"
                                        @hideListFuntion="hideListFuntion"
                                    />
                                </div>
                                
                            </td>
                            </tr>
                    </tbody>
                </table> 
            </div>
            <div class="footer">
               <div class=" CountRecord"> Tổng số: <span class="totalRecord">{{this.totalRecord}}</span> bản ghi </div>
                <div class="pos-page">
                    <select name="" id="NRPP" v-model="selectPageSize" @change="selectPageSizeOnClick(selectPageSize)">
                        <option value="20">20 bản ghi một trang</option>
                        <option value="50">50 bản ghi một trang</option>
                        <option value="100">100 bản ghi một trang</option>
                    </select>
                    <button class="btn-forward first" @click="PreOnClick()">Trước</button> 
                    <button class="paging pagenumber" :class="{'IsActive': this.currentPage==this.pageOne  }" @click="PageOneOnClick()">{{this.pageOne}}</button>
                    <button class="paging threeDots" :class="{'displayThreeDotsFirst':(this.pagePreMid==2) || this.pageLast < 5}" @click="DotFrontOnclick()" >...</button>
                    <button class="paging pagenumber" :class="{'IsActive': this.currentPage==this.pagePreMid, 'display': this.pageLast<2 }" @click="PagePreMidOnClick()">{{this.pagePreMid}}</button>
                    <button class="paging pagenumber" :class="{'IsActive': this.currentPage==this.pageMid, 'display' : this.pageLast <3}" @click="PageMidOnClick()">{{this.pageMid}}</button>
                    <button class="paging pagenumber" :class="{'IsActive': this.currentPage==this.pageBehMid, 'display' :this.pageLast <4}" @click="PageBehMidOnClick()">{{this.pageBehMid}}</button>
                    <button class="paging threeDots" :class="{'displayThreeDotsFirst':(this.pageBehMid ==this.pageLast-1) || this.pageLast < 5}" @click="DotBehindOnclick()">...</button>
                    <button class="paging pagenumber" :class="{'IsActive': this.currentPage==this.pageLast , 'display' : this.pageLast < 5}" @click="PageLastOnClick()">{{this.pageLast}}</button>
                    <button class="btn-forward next" @click="NextOnClick()">Sau</button>
                </div>
            </div>
            </div>
            <CustomerDetail
                :formMode ="formMode"
                :isShow="isShowDialogDetail"
                :employee="selectedEmp"
                @hideDialog="hideDialog"
                @AddMore="AddMore"
                :isAddMore ="this.isAddMore"
                ref="empCode"
            />
            <NotiDelete
            :isShowNotiDelete ="isShowNotiDelete"
            @HideNotiDelete="HideNotiDelete"
            :idToDelete ="this.currentId"
            :empCodeToDelete="this.empCodeToDelete"
            />

    </div>
</template>
<script>
import NotiDelete  from "../notifications/notiDelete"
import CustomerDetail from "./customerDetails.vue"
//import ListFunction from "./listFunction.vue"
import axios from 'axios'
import ListFunction from '../notifications/listFunction.vue';
export default {
    components:{
        CustomerDetail,
        ListFunction, 
        NotiDelete,
    },
    created(){
        //this.loadData();
        this.clickOutSize(); 
        this.loadPaging();
    },
    
    props:[],
    data() {
        return {
            grpByDepartId:"",
            grpByPosId :"",
            Res : [],
            setGrpByDepartId:"0",
            setGrpByPosId:"0",
            isShowDialogDetail : false,
            employees : [],
            formMode : "add",
            selectedEmp:{},
            isShowListFunction : false,
            currentId : "",
            isShowNotiDelete : false,
            empCodeToDelete: "",
            isAddMore : false,
            showDotFront: false,
            showDotBehind : true,
            pageOne: 1,
            pageLast:0,
            pagePreMid:2,
            pageMid:3,
            pageBehMid:4,
            currentPage:1,
            PageSize:20,
            SearchString: "",
            totalRecord :0,
            stringInput : "",
            selectPageSize : 20,

        }
    },  
    methods:{
        SetGrPosId(data){
            this.setGrpByPosId=data;
            console.log("posss")
        },
        SetGrDepartId(data){
            this.setGrpByDepartId =data;
            console.log("depaaa")
        },
        clickOutSize(){
            var o = this; 
            window.addEventListener('click', function(e){   
                var check = false; 
                var listEl = document.getElementsByClassName('listFuncEmp');  
                for( var i = 0 ; i < listEl.length; i++){
                    if(listEl[i].contains(e.target)){
                        check = true; 
                        break; 
                    }
                }
                if (check){
                    // Clicked in bo
                } else{
                    // Clicked outside the box
                    o.isShowListFunction = false; 

                }
            });
        },
        InputSearchString(string){
            this.SearchString = string;
            this.currentPage = 1;
            this.pageOne = this.currentPage;
            //console.log(this.SearchString.length);
            console.log( "nhập input"+this.currentPage);
            this.loadPaging();
            
        },
        selectPageSizeOnClick(selectPageSize){
            this.PageSize = selectPageSize;
            this.currentPage =1;
            //console.log(this.PageSize);
            this.loadPaging();
        },
        PreOnClick(){
            if (this.currentPage > 1){
                this.currentPage= this.currentPage-1;
                if(this.currentPage < this.pageLast - 3 && this.currentPage > 1){
                this.pagePreMid = this.currentPage;
                this.pageMid = this.pagePreMid +1;
                this.pageBehMid = this.pageMid+1;
                }
                this.loadPaging();
            }
            
            
        },
        NextOnClick(){
            if(this.currentPage < this.pageLast){
                this.currentPage +=1;
                if(this.currentPage > 1 && this.currentPage < this.pageLast -2){
                this.pagePreMid = this.currentPage;
                this.pageMid = this.pagePreMid +1;
                this.pageBehMid = this.pageMid+1;
                }
                this.loadPaging();
            }
            
            
        },
        PageOneOnClick(){
            this.currentPage =this.pageOne;
             this.loadPaging();
        },
        PagePreMidOnClick(){
            this.currentPage = this.pagePreMid;
            this.loadPaging();
        },
        PageMidOnClick(){
            this.currentPage = this.pageMid;
            this.loadPaging();
        },
        PageBehMidOnClick(){
            this.currentPage = this.pageBehMid;
            this.loadPaging();
        },
        PageLastOnClick(){
            this.currentPage = this.pageLast;
            this.loadPaging();
        },
        DotFrontOnclick(){
            if(this.pagePreMid-2 <= this.pageOne ){
                this.pagePreMid =this.pageOne +1;
                this.pageMid = this.pagePreMid +1;
                this.pageBehMid = this.pageMid +1;

            }
            else{
                this.pagePreMid= this.pagePreMid-2;
                this.pageMid = this.pageMid-2;
                this.pageBehMid =  this.pageBehMid -2;
            }
        },
        DotBehindOnclick(){
            if(this.pageBehMid+2 >= this.pageLast){
                this.pageBehMid = this.pageLast-1;
                this.pageMid = this.pageBehMid -1;
                this.pagePreMid = this.pageMid -1;
            }
            else
            {
                this.pageBehMid =  this.pageBehMid+2;
                this.pagePreMid= this.pagePreMid+2;
                this.pageMid = this.pageMid+2;
            }
        },

        loadPaging(){
            axios
            .get("https://localhost:44333/api/v1/Employees/getPaging?PageNumber="+this.currentPage+"&PageSize=" +this.PageSize +"&SearchString="+this.SearchString)
            .then((res)=>{
                this.employees = res.data;
                //console.log(this.employees.length);
                if(this.employees.length> 0){
                    this.totalRecord = this.employees[0].totalRecord;
                    //console.log(this.totalRecord);
                    //console.log(this.employees[0]);
                    if(this.totalRecord % this.PageSize !=0){
                        this.pageLast = (this.totalRecord -this.totalRecord % this.PageSize)/this.PageSize +1 ;
                    }
                    else{
                        this.pageLast = (this.totalRecord -this.totalRecord % this.PageSize)/this.PageSize;
                    }
    
                }

                else this.totalRecord = 0;

            })
            .catch((res)=>{
                console.log(res);
            })
        },
        loadData(){
            axios
            .get("https://localhost:44333/api/v1/Employees")
            .then((res)=>{
                this.employees = res.data;
            })
            .catch((res)=>{
                console.log(res);
            })
        },
        RefreshOnClick(){
            this.loadPaging();

        },
        listFuncOnClick(id,code){
            if(this.isShowListFunction) {
                this.isShowListFunction = false;
                this.currentId = "";
                this.empCodeToDelete = "";
            }
            else 
            {
                this.empCodeToDelete=code;
                this.currentId = id;
                this.isShowListFunction =true;
            }
            console.log(this.currentId);
            console.log(this.empCodeToDelete);
        },
        async getNewCode(){
            this.formMode="add";
            await axios
            .get("https://localhost:44333/api/v1/Employees/getNewCode")
            .then((res)=>{
                this.selectedEmp.employeeCode = res.data;
            })
            .catch((res)=>{
                console.log(res);
            })
            this.selectedEmp={employeeCode: this.selectedEmp.employeeCode};
        },
        AddMore(){
            //this.AddMore =true;
            this.getNewCode();
            
            console.log(this.isShowDialogDetail);
        },
        addCusOnClick(){
            this.isShowDialogDetail= true;
            this.getNewCode();
        },
        hideDialog(){
            this.isShowDialogDetail= false;
            this.loadPaging();
        },
        hideListFuntion(){
            this.isShowListFunction = false;
            this.isShowNotiDelete = true;
        },
        HideNotiDelete(){
            this.isShowNotiDelete = false;
            this.loadPaging();
        },
        formatGender(data){
            if(data==0){
                return "Nữ";
            }
            if(data==1){
                return "Nam";
            }
            return "Không xác định";
        },
        formatDate(data){
            var date = data + "";
            if(date=="null") return "";
            var result = date.substr(5,2)+"/"+date.substr(8,2) +"/"+date.substr(0,4);
            return result
        },
        formatDateForDetail(data){
            var date = data + "";
            if(date=="null") return "";
            var result = date.substr(0,4) +"-"+ date.substr(5,2)+"-"+date.substr(8,2);
            return result
        },
        empOnClick(EmployeeId){
            this.formMode="EDIT";
            axios
            .get("https://localhost:44333/api/v1/Employees/"+EmployeeId)
            .then((res)=>{
                this.selectedEmp = res.data;
                this.selectedEmp.dateOfBirth= this.formatDateForDetail(this.selectedEmp.dateOfBirth)
                console.log(this.selectedEmp);
                this.isShowDialogDetail=true;
            })
            .catch((res)=>{
                console.log(res);
            })
        },
        TakeIdDel(employeeId){
                this.isDelete = employeeId;
        },
    },
    watch:{}
    
}
</script>
<style>
@import '../../style/Content.css';
</style>