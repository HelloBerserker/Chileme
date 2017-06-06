 window.onscroll=function(){
        var top=window.pageYOffset;
        var fixed = document.getElementsByClassName("success")[0];
        var pull= document.getElementsByClassName("pull-down")[0];
                var y=fixed.offsetTop+"px";
        if(top>130)
        {
        	fixed.style.position="fixed";
        	fixed.style.top = "0px";
        	pull.style.top= "0px";
        }
        else
        {
        	fixed.style.position="relative";
        	      	
        }
    }
