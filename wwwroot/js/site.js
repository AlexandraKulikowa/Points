//var canvasWidth = 600;
//var canvasHeight = 400;
//var stage = new Konva.Stage({
//    container: "example",
//    width: canvasWidth,
//    height: canvasHeight
//});
//var layerA = new Konva.Layer();
//var rectA = new Konva.Rect({
//    x: 75,
//    y: 150,
//    width: 200,
//    height: 50,
//    rotation: 45,
//    fill: "blue",
//    stroke: "black",
//    strokeWidth: 4
//});
//var rectB = new Konva.Rect({
//    x: 350,
//    y: 50,
//    width: 100,
//    height: 250,
//    cornerRadius: 50,
//    fill: "red",
//    stroke: "brown",
//    strokeWidth: 10
//});
//layerA.add(rectA);
//layerA.add(rectB);
//stage.add(layerA);


function GetContainer() {
    $.ajax({
        type: 'GET',
        url: '/Home/GetPoints',
        success: function (response) {
            Draw(response);
        },
        error: function (error) {
            console.log(error)
            alert('Error');
        }
    });
}
function Draw(response) {
    var width = window.innerWidth;
    var height = window.innerHeight;

    var stage = new Konva.Stage({
        container: 'container',
        width: width,
        height: height
    });

    var layer = new Konva.Layer();

    for (var i = 0; i < response.length; i++) {
        var group = new Konva.Group(),
        var circle = new Konva.Circle({
            x: response[i].X,
            y: response[i].Y,
            radius: response[i].Radius,
            fill: response[i].color,
            name: response[i].id + ''
        })

        circle.on('dblclick', function (e) {
            var id = e.currentTarget.attrs.name;
            $.ajax({
                url: "/Home/DeletePoint",
                type: "post",
                datatype: "text",
                data: { id: id },
                success: function (response) {
                    if (response) {
                        var items = stage.find('.' + id);
                        for (var i = 0; i < items.length; i++) {
                            items[i].destroy();
                        }
                        layer.draw();
                    }
                    else
                    { alert("Error") }
                }
            });
        })

        group.add(circle);

        var starPosition = response[i].Y + response[i].Radius + 3;
        for (var j = 0; j < response[i].Comments.length; j++) {
            var simpleLabel = new Konva.Label({
                x: (response[i].X - (response[i].Comments[j].text.Length * 5)),
                y: starPosition,
                opacity: 0.5,
            });

            simpleLabel.add(
                new Konva.Tag({
                    fill: response[i].comments[j].BackgroundColor,
                    stroke: "Grey",
                    name: response[i].id + ''
                })
            );

            simpleLabel.add(
                new Konva.Text({
                    text: response[i].comments[j].text,
                    fontFamily: 'Arial',
                    fontSize: 14,
                    padding: 3,
                    fill: 'Green',
                    name: response[i].id + ''
                })
            );

            group.add(simpleLabel)
            starPosition += 30;
        }
        layer.add(group);
    }
    stage.add(layer);
}