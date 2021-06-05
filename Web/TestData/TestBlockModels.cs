using System.Collections.Generic;
using Web.Models;

namespace Web.TestData
{
    public class TestBlockModels
    {
        public static IList<BlockModel> BlockModels = new List<BlockModel>()
        {
            new BlockModel()
            {
                Links = new List<LinkModel>()
                {
                    new LinkModel()
                    {
                        Description =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam semper nisl vel sem placerat malesuada. Duis dapibus vehicula felis, eget placerat est varius in. Nullam non aliquet neque, eget rutrum nisl. Fusce ac finibus massa. Donec semper consectetur rutrum. Duis quis pharetra tellus. Etiam sit amet tristique ex. Sed ante sapien, lacinia sit amet odio sed, posuere pretium metus. Duis facilisis elit nec erat dapibus bibendum. Aenean pharetra, magna dictum gravida imperdiet, orci libero efficitur libero, elementum fermentum ipsum leo ac mauris. Sed justo orci, scelerisque ut tincidunt at, consequat ac lorem.",
                        Link = "https://Loremipsum.test.longlink.com",
                        Title = "Lorem ipsum",
                        Order = 0
                    },
                    new LinkModel()
                    {
                        Description = "Some desc2",
                        Link = "https://test.test",
                        Title = "Title of link 2",
                        Order = 1
                    },
                    new LinkModel()
                    {
                        Link = "https://test.test",
                        Title = "Title of link 3",
                        Order = 2
                    },
                    new LinkModel()
                    {
                        Description =
                            "Suspendisse potenti. Etiam turpis arcu, sodales eu porttitor sed, ornare ut justo. Maecenas ac urna pellentesque, bibendum nulla sed, aliquam neque. Nunc bibendum orci et elementum efficitur. Phasellus non iaculis urna. Integer aliquam elit ut magna rutrum, nec ultrices nisi ullamcorper. Nam aliquet vehicula nulla, eget rhoncus quam feugiat id. Fusce nec urna ipsum. Nam imperdiet aliquet ante id blandit.",
                        Link = "https://test.test/asdasd?sdfsdf=dfdfdf&sdfsdfsdf=dfd",
                        Title = "Title of link 4",
                        Order = 3
                    },
                    new LinkModel()
                    {
                        Description =
                            "Fusce vel commodo metus, id ullamcorper leo. Nulla aliquet lectus non tortor aliquet maximus. Phasellus scelerisque libero et congue dictum. Donec scelerisque facilisis libero, in malesuada velit semper quis. Donec non vehicula massa. Donec feugiat, dolor a pulvinar porta, ligula lorem gravida lorem, sed euismod elit lectus nec mi. Nam non enim nisl. Vivamus a urna mauris. Sed accumsan nisl vel ex ullamcorper, eget cursus metus semper. Curabitur lobortis sapien ac iaculis commodo. Fusce sollicitudin feugiat lectus, vitae sodales mauris fringilla quis. Donec sed porttitor est, quis tristique felis. Vestibulum tincidunt pretium ligula, vitae egestas urna venenatis porta. Duis quam ex, fermentum ut velit eget, accumsan tempor metus.",
                        Link = "https://google.com",
                        Title = "Title of link 5",
                        Order = 4
                    },
                    new LinkModel()
                    {
                        Link = "https://test.test",
                        Title = "Title of link 6",
                        Order = 5
                    },
                    new LinkModel()
                    {
                        Description = "Some desc7",
                        Link = "https://test.test",
                        Title = "Title of link 7",
                        Order = 6
                    },
                    new LinkModel()
                    {
                        Description = "Some desc7",
                        Link = "https://test.test",
                        Title = "Title of link 7",
                        Order = 7
                    }
                },
                Title = "Test title 1"
            },
            new BlockModel()
            {
                Links = new List<LinkModel>()
                {
                    new LinkModel()
                    {
                        Description = "Some desc1",
                        Link = "https://test.test",
                        Title = "Title of link 1"
                    },
                    new LinkModel()
                    {
                        Description = "Some desc2",
                        Link = "https://test.test",
                        Title = "Title of link 2"
                    },
                    new LinkModel()
                    {
                        Description = "Some desc3",
                        Link = "https://test.test",
                        Title = "Title of link 3"
                    },
                    new LinkModel()
                    {
                        Description = "Some desc4",
                        Link = "https://test.test",
                        Title = "Title of link 4"
                    },
                    new LinkModel()
                    {
                        Description = "Some desc5",
                        Link = "https://test.test",
                        Title = "Title of link 5"
                    }
                },
                Title = "Test title 2"
            }
        };
    }
}