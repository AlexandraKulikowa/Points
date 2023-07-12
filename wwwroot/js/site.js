function GetPoints() {
    $.ajax({
        type: 'GET',
        url: 'Home/GetPoints',
        dataType: 'json',
        success: function (data) {
            var width = window.innerWidth;
            var height = window.innerHeight;
            var container = new Konva.Stage({
                container: 'Points',
                width: width,
                height: height
            });

            var layer = new Konva.Layer();

            for (var i = 0; i < data.length; i++) {
                var group = new Konva.Group();
                var point = new Konva.Circle({
                    x: data[i].x,
                    y: data[i].y,
                    radius: data[i].radius,
                    fill: data[i].color,
                    name: data[i].pointId + ''
                });

                point.on('dblclick', function (e) {
                    var id = e.currentTarget.attrs.name;
                    $.ajax({
                        type: 'POST',
                        url: 'Home/DeletePoint',
                        dataType: 'text',
                        data: { pointid: id },
                        success: function (response) {
                            if (response) {
                                var shapes = container.find('.' + id);
                                for (var i = 0; i < shapes.length; i++) {
                                    shapes[i].destroy();
                                }
                                layer.draw();
                            }
                            else {
                                alert("Error");
                            }
                        }
                    });
                });

                group.add(point);

                var lowPosition = data[i].y + data[i].radius + 2;
                for (var j = 0; j < data[i].comments.length; j++) {
                    var str = data[i].comments[j].text;
                    var comment = new Konva.Label({
                        x: data[i].x,
                        offsetX: (data[i].comments[j].text.length * 8) / 2 + 2,
                        y: lowPosition,
                        opacity: 0.9,
                    });

                    comment.add(
                        new Konva.Tag({
                            fill: data[i].comments[j].backgroundColor,
                            stroke: "Gray",
                            name: data[i].pointId + ''
                        })
                    );

                    comment.add(
                        new Konva.Text({
                            text: data[i].comments[j].text,
                            fontFamily: 'Calibri',
                            fontSize: 14,
                            padding: 3,
                            fill: 'Green',
                            name: data[i].pointId + ''
                        })
                    );
                    group.add(comment)
                    lowPosition += 23;
                }
                layer.add(group);
            }
            container.add(layer);
        },
        error: function (ex) {
            alert("Error!\n ExceptionType: " + ex.ExceptionType);
        }
    });
}