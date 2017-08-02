using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Framework;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Allocation;
using OpenTK.Graphics;
using osu.Framework.Input;
using osu.Framework.Graphics.Sprites;
using OpenTK;

namespace TouhouOnline.Game
{
    public class TouhouOnlineGame : osu.Framework.Game
    {
        string[] args;
        protected override IReadOnlyDependencyContainer CreateLocalDependencies(IReadOnlyDependencyContainer parent) =>
            new DependencyContainer(base.CreateLocalDependencies(parent));

        public TouhouOnlineGame(string[] args) : base()
        {
            Name = @"Touhou Online";
            this.args = args;
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();

            Child = new FillFlowContainer<HoverResponsibleContainer>
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Children = new[]
                {
                    new HoverResponsibleContainer
                    {
                        Origin = Anchor.Centre,
                        Colour = Color4.BurlyWood,
                        Size = new Vector2(100, 200),
                        Text = "duh",
                    },
                    new HoverResponsibleContainer
                    {
                        Origin = Anchor.Centre,
                        Colour = Color4.BurlyWood,
                        Size = new Vector2(300, 200),
                        Text = "Second One",
                    },
                    new HoverResponsibleContainer
                    {
                        Origin = Anchor.Centre,
                        Colour = Color4.BurlyWood,
                        Size = new Vector2(500, 200),
                        Text = "This one is big :o",
                    }
                }
            };
        }

        private class HoverResponsibleContainer : Container
        {
            private Color4 initialColour;
            private Color4 hoverColour;
            private Box color;
            private Box flash;
            private SpriteText text = new SpriteText();
            public string Text { get { return text.Text; } set { text.Text = value; } }

            [BackgroundDependencyLoader]
            private void load()
            {
                initialColour = Colour;
                Colour = Color4.White;
                hoverColour = new Color4(Math.Min(1, initialColour.R + 0.1f), Math.Min(1, initialColour.G + 0.1f), Math.Min(1, initialColour.B + 0.1f), Math.Min(1, initialColour.A + 0.1f));
                Children = new Drawable[]
                {
                    color = new Box
                    {
                        Colour = initialColour,
                        RelativeSizeAxes = Axes.Both,
                    },
                    text = new SpriteText
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Text = Text,
                        TextSize = 30,
                    },
                    flash = new Box
                    {
                        Colour = Color4.White,
                        Alpha = 0,
                        RelativeSizeAxes = Axes.Both,
                    }
                };
            }

            protected override bool OnHover(InputState state)
            {
                color.FadeColour(hoverColour, 200);
                return base.OnHover(state);
            }

            protected override void OnHoverLost(InputState state)
            {
                color.FadeColour(initialColour, 200);
                base.OnHoverLost(state);
            }

            protected override bool OnClick(InputState state)
            {
                flash.FadeIn().Then().FadeOut(75);
                return base.OnClick(state);
            }
        }
    }
}
