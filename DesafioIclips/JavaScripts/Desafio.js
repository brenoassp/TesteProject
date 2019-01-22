//lorems = [
//    {
//        "name": "Aliqua aliquip",
//        "email": "exemplo@square.com.br",
//        "status": "atrasado",
//        "tag": ""
//    },
//    {
//        "name": "Dolore aliqua veniam",
//        "email": "exemplo@square.com.br",
//        "status": "andamento",
//        "tag": ""
//    },
//    {
//        "name": "Eliusmod duis proident",
//        "email": "teste@ipixel.com",
//        "status": "andamento",
//        "tag": "alteração"
//    },
//    {
//        "name": "Exercitation enim",
//        "email": "exemplo@square.com.br",
//        "status": "andamento",
//        "tag": "novo"
//    },
//    {
//        "name": "Labore nulla",
//        "email": "exemplo@square.com.br",
//        "status": "andamento",
//        "tag": ""
//    },
//    {
//        "name": "Lorem pariatur ipsum",
//        "email": "teste@ipixel.com",
//        "status": "andamento",
//        "tag": "novo"
//    },
//    {
//        "name": "Occaecat adipisicing",
//        "email": "teste@ipixel.com",
//        "status": "andamento",
//        "tag": ""
//    },
//]

//var progress_count = 0;
//var delayed_count = 0;
//var new_items_count = 0;

//$.each(lorems, function () {
//    if (this.status === "atrasado") {
//        delayed_count += 1;
//        progress_count += 1;
//    } else if (this.status === "andamento") {
//        progress_count += 1;
//    }
//});

//$(".badge-andamento").text(progress_count);
//$(".badge-atrasadas").text(delayed_count);

//function create_table(lorems, status) {
//    new_lorems = []
//    if (status !== "all") {
//        lorems.forEach(function (el) {
//            if (el.status === status) {
//                new_lorems.push(el);
//            }
//        })
//    } else {
//        new_lorems = lorems
//    }

//    let tbl_body = "";
//    let odd_even = false;
//    rows = ""
//    $.each(new_lorems, function () {
//        var tbl_row = "";

//        new_tr = "<tr>"

//        name_column = "<td width=\"40%\" class=\"\"><div class=\"pl-20\"><input class=\"va-middle\" type=\"checkbox\"><span class=\"ml-20\">" + this.name + "</span></div></td>"

//        email_column = "<td width=\"40%\">" + this.email + "</td>"

//        tag_column = "<td class=\"columnTag\"><div class=\"f-right mr-20 text-center allign-middle\"><span class=\"tag\">" + this.tag + "</span></div></td>"

//        end_tr = "</tr>"

//        if (this.tag) {
//            tag_column_obj = $(jQuery.parseHTML(tag_column)[0]);
//            //se for alteração entao adicionar classe danger
//            if (tag_column_obj.text() === 'novo') {
//                span_tag = tag_column_obj.find(".tag")
//                span_tag.addClass("bg-info")
//            }
//            //se for novo classe info
//            if (tag_column_obj.text() === 'alteração') {
//                span_tag = tag_column_obj.find(".tag")
//                span_tag.addClass("bg-danger")
//            }
//            tag_column = "<td class=\"columnTag\">" +
//                tag_column_obj.html() + "</td>"
//        }

//        row = name_column + email_column + tag_column

//        rows += "<tr class=\"" + (odd_even ? "odd" : "even") + "\">" + row + "</tr>";
//        odd_even = !odd_even;
//    })
//    $("#table_lorem tbody").html(rows);
//    $("tr").click(function () {
//        $(this).addClass("selected").siblings().removeClass("selected");
//    });
//}

//create_table(lorems, "all")

$(".sidebar-item").click(function () {
    //selected_option = $(this).text().split("\n")[1].replace(/ /g, '');
    //if (selected_option === "ATRASADAS") {
    //    ////create_table(lorems, "atrasado")
    //}
    //if (selected_option === "EMANDAMENTO") {
    //    create_table(lorems, "all")
    //}
    $(this).addClass("sidebar-selected-item").siblings().removeClass("sidebar-selected-item");
});

//$(".btn-cadastro").click(function () {
//    new_items_count += 1
//    new_item_name = "novo item " + new_items_count.toString()
//    new_item = {
//        "name": new_item_name,
//        "email": "teste@ipixel.com",
//        "status": "andamento",
//        "tag": "novo"
//    }
//    lorems.push(new_item);
//    $(".sidebar-selected-item").click();
//    $(".badge-andamento").text(progress_count + new_items_count);
//});
