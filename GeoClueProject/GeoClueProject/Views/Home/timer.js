
    <script>
        console.log("Resetting");
        localStorage.setItem('IsTimerOn', false);

    </script>


     var remSeconds = 60;
         function startTick() {


             document.getElementById("timer").innerHTML = remSeconds;

            var _tick = setInterval(function () {
                remSeconds = remSeconds - 1;
                document.getElementById("timer").innerHTML = remSeconds;

                if (remSeconds == 0) {
                    alert('New guess !');
                    localStorage.setItem('IsTimerOn', true);
                    clearInterval(_tick);
                    location.reload();
                    

                }

            }, 1000);

        }
        var IsTimerOn = localStorage.getItem("IsTimerOn");
        console.log(IsTimerOn);
        if (IsTimerOn=="true") {

            console.log("starting");
            startTick();
        }
        else
            console.log("Not starting");
       