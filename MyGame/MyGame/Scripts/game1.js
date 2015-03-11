﻿var pics = new Array();
for (i = 0; i <= 18; i++) {
    pics[i] = new Image();
    pics[i].src = '../Content/1/image' + i + '.png';
}
var map=new Array(1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12, 12, 13, 13, 14, 14, 15, 15, 16, 16, 17, 17, 18, 18);
var user = new Array();
var temparray = new Array();
var clickarray = new Array(0, 0);
var ticker, sec, min, ctr, id, oktoclick, finished;
function init1() {
    document.body.style.backgroundImage = "url('../Content/1/1.jpg')";
    clearTimeout(id);
    for (i = 0; i <= 35 ;i++) {
        user[i] = 0;
    }
    ticker = 0;
    min = 0;
    sec = 0;
    ctr = 0;
    oktoclick = true;
    finished = 0;
    document.f.olympic.value = "";
    scramble();
    runclk();
    for (i = 0; i <= 35; i++) {
        document.f[('img' + i)].src = "../Content/1/image0.png";
    }
}
function runclk() {
    min = Math.floor(ticker/60);
    sec = (ticker-(min*60))+'';
    if(sec.length == 1) {sec = "0"+sec};
    ticker++;
    document.f.olympic.value = "Time passed: <" + min + ":" + sec + "> Click to reset";
    id = setTimeout('runclk()', 1000);
}
function scramble() {
    for (z = 0; z < 5; z++) {
        for (x = 0; x <= 35; x++) {
            temparray[0] = Math.floor(Math.random()*36);
            temparray[1] = map[temparray[0]];
            temparray[2] = map[x];
            map[x] = temparray[1];
            map[temparray[0]] = temparray[2];
        }
    }
}
function showimage(but) {
    if (oktoclick) {
        oktoclick = false; 
        document.f[('img' + but)].src = '../Content/1/image' + map[but] + '.png';
        if (ctr == 0) {
            ctr++;
            clickarray[0] = but;
            oktoclick = true;
        } else {
            clickarray[1] = but;
            ctr = 0;
            setTimeout('returntoold()', 600);
        }
    }
}
function returntoold() {
    if ((clickarray[0] == clickarray[1]) && (!user[clickarray[0]])) {
        document.f[('img' + clickarray[0])].src = "../Content/1/image0.png";
        oktoclick = true;
    } else {
        if (map[clickarray[0]] != map[clickarray[1]]) {
            if (user[clickarray[0]] == 0) {
                document.f[('img' + clickarray[0])].src = "../Content/1/image0.png";
            }
            if (user[clickarray[1]] == 0) {
                document.f[('img' + clickarray[1])].src = "../Content/1/image0.png";
            }
        }
        if (map[clickarray[0]] == map[clickarray[1]]) {
            if (user[clickarray[0]] == 0&&user[clickarray[1]] == 0) { finished++; }
            user[clickarray[0]] = 1;
            user[clickarray[1]] = 1;
        }
        if (finished >= 18) {
            alert('You did it in ' + document.f.olympic.value + ' !');
        } else {
            oktoclick = true;
        }
    }
}
