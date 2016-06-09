
$(document).ready(function () {
    //$('#get-data').click(function () {
        
        var showData = $('#show-data');

        $.getJSON('http://clevelandhistorical.org/items/browse?search=&advanced[0][element_id]=39&advanced[0][type]=is+exactly&advanced[0][terms]=Richard%20Raponi&output=mobile-json', function (data) {
            console.log(data);
            var items = data.items.map(function (item) {
                return  (("<a href=\"http://clevelandhistorical.org/items/show/" + item.id + "\">") + (item.title) + ("</a>")) + '<BR>' + ("<img src='" + item.thumbnail + "' />") + '<BR>' + '<BR>';
            });

            //return item.id + ': ' + ': ' + item.title + ' ' + item.latitude + ' ' + item.longitude + ' ' + item.address + ' ' + (("<a href=\"http://clevelandhistorical.org/items/show/" + item.id + "\">") + (item.title) + ("</a>")) + ' ' + ' ' + ("<img src='" + item.thumbnail + "' />");

            showData.empty();
            if (items.length) {
                var content = '<li>' + items.join('</li><li>') + '</li>';
                var list = $('<ul />').html(content);
                showData.append(list);

            }
        });

        showData.text('Test');
    //});
});

//$(document).ready(function () {
//    $('#get-data').click(function () {
        
//        var showData = $('#show-data');

//        $.getJSON('http://clevelandhistorical.org/items/browse?search=&advanced[0][element_id]=39&advanced[0][type]=is+exactly&advanced[0][terms]=Richard%20Raponi&output=mobile-json', function (data) {
//            console.log(data);
//            var items = data.items.map(function (item) {
//                return item.id + ' ' + ': ' + item.title + ' ' + item.latitude + ' ' + item.longitude + ' ' + item.address + ' ' + (("<a href=\"http://clevelandhistorical.org/items/show/" + item.id + "\">") + (item.title) + ("</a>")) + ' ' + ' ' + ("<img src='" + item.thumbnail + "' />");
//            });

       
//            showData.empty();
//            if (items.length) {
//                var content = '<li>' + items.join('</li><li>') + '</li>';
//                var list = $('<ul />').html(content);
//                showData.append(list);

//            }
//        });

//        showData.text('Loading the JSON file.');
//    });
//});
