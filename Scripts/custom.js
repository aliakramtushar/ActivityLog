var win = null
function progressBarOpen() {

    win = $.messager.progress({
        title: 'Please Wait',
        msg: 'Loading data...'
    });
}
function progressBarClose() {
    $.messager.progress('close');
}
