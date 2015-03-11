for (r = 0; r <= 5; r++) {
    document.write('<table cellpadding="5px" cellspacing="0" border="0"><tr>');
    for (c = 0; c <= 5; c++) {
        document.write('<td align="center">');
        document.write('<a href="javascript:showimage(' + ((6 * r) + c) + ')" onClick="document.f.olympic.focus()">');
        document.write('<img src="../Content/1/image0.png" name="img' + ((6 * r) + c) + '" border="0">');
        document.write('</a></td>');
    }
    document.write('</tr></table>');
}