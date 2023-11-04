var btnClick = document.querySelector('#btn-click');
var img = document.querySelector('#img-dog');
let isClick = false;


btnClick.addEventListener("click", ()=>{
  if(isClick){
    btnClick.innerHTML = "Click Me";
    isClick = false;
  }
  else{
    btnClick.innerHTML = "Me Click";
    isClick = true;
  }
  
})