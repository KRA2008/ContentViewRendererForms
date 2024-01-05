using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics;
using Android.Views;
using ContentViewRendererForms;
using ContentViewRendererForms.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;

[assembly: ExportRenderer(typeof(MyContentView), typeof(MyContentViewRenderer))]
namespace ContentViewRendererForms.Droid
{
    public class MyContentViewRenderer : ViewRenderer<MyContentView, View>,
        TextureView.ISurfaceTextureListener
    {
        protected override void OnElementChanged(ElementChangedEventArgs<MyContentView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var textureView = new TextureView(Context);
                textureView.SurfaceTextureListener = this;

                AddView(textureView);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }

        public void OnSurfaceTextureAvailable(SurfaceTexture surface, int width, int height)
        {
            System.Diagnostics.Debug.WriteLine("### the SurfaceTexture has become available!");
            Debugger.Break();
        }

        public bool OnSurfaceTextureDestroyed(SurfaceTexture surface)
        {
            return true;
        }

        public void OnSurfaceTextureSizeChanged(SurfaceTexture surface, int width, int height)
        {
        }

        public void OnSurfaceTextureUpdated(SurfaceTexture surface)
        {
        }
    }
}