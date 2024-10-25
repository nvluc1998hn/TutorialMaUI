using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls.Shapes;
using System.ComponentModel;
using TutorialMaUI.Enums;


namespace TutorialMaUI.PopUp;

public partial class PopupInfoCamera : Popup, INotifyPropertyChanged
{
    private bool _haveImage = false;
    public event EventHandler Accepted;
    public string ImageBase64;
    public bool HaveImage
    {
        get => _haveImage;
        set
        {
            _haveImage = value;
            OnPropertyChanged(nameof(HaveImage));
        }
    }

    public PopupInfoCamera(bool haveImage, string imageBase64)
    {
        HaveImage = haveImage;
        ImageBase64 = imageBase64;
        this.CreateTemplate(HaveImage);
        InitializeComponent();
    }

    public void CreateTemplate(bool haveImage)
    {
        var border = new Border
        {
            Padding = 0,
            Margin = 0,
            BackgroundColor = Colors.White,
            HeightRequest = HaveImage ? 270 : 180,
            HorizontalOptions = LayoutOptions.Center,
            StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(20) },
            StrokeThickness = 2,
            VerticalOptions = LayoutOptions.Center,
            WidthRequest = 300
        };

        // Grid layout
        var gridOrigin = new Grid();
        gridOrigin.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto }); // Row cho tiêu đề
        gridOrigin.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });  // Row cho các nút
        gridOrigin.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto }); // Row cho nút đóng

        var grid = new Grid();
        grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto }); // Row cho nút "Chọn ảnh từ thiết bị"
        grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto }); // Row cho nút "Chụp ảnh"

        if (haveImage)
        {
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto }); // Row cho nút "Xem chi tiết ảnh"
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto }); // Row cho nút "Xóa ảnh"
        }

        // StackLayout cho phần tiêu đề
        var titleStackLayout = new StackLayout
        {
            BackgroundColor = Color.FromArgb("#0959a0"),
            HorizontalOptions = LayoutOptions.Fill
        };

        // Label cho tiêu đề
        var titleLabel = new Label
        {
            Padding = 10,
            FontSize = 15,
            HorizontalOptions = LayoutOptions.Center,
            Text = "Thông tin ảnh",
            TextColor = Colors.White,
            VerticalOptions = LayoutOptions.Center
        };

        // Thêm label vào titleStackLayout
        titleStackLayout.Children.Add(titleLabel);

        // Thêm titleStackLayout vào gridOrigin
        gridOrigin.SetRow(titleStackLayout, 0);
        gridOrigin.Children.Add(titleStackLayout);

        // Thêm grid vào gridOrigin tại hàng 1
        gridOrigin.SetRow(grid, 1);
        gridOrigin.Children.Add(grid);

        // Nếu có hình ảnh, thêm các nút
        if (haveImage)
        {
            // Nút chi tiết ảnh
            var detailButton = new Button
            {
                HeightRequest = 35,
                Text = "Xem chi tiết ảnh",
                Margin = 5
            };
            detailButton.Clicked += (sender, args) =>
            {
                var pop = new DetailImagePopup(ImageBase64);
                Application.Current.MainPage.ShowPopup(pop);
                this.Close();
            };
            grid.SetRow(detailButton, 0);
            grid.Children.Add(detailButton); // Thêm vào hàng 0

            // Nút chọn ảnh
            var chooseImageButton = new Button
            {
                HeightRequest = 35,
                Text = "Chọn ảnh từ thiết bị",
                Margin = 5
            };
            chooseImageButton.Clicked += (sender, args) =>
            {
                Accepted?.Invoke(ImageCameraEnum.ChosseFromDevice, EventArgs.Empty);
                this.Close();
            };
            grid.SetRow(chooseImageButton, 1);
            grid.Children.Add(chooseImageButton); // Thêm vào hàng 1

            // Nút chụp ảnh
            var takeImageButton = new Button
            {
                HeightRequest = 35,
                Text = "Chụp ảnh",
                Margin = 5
            };
            takeImageButton.Clicked += (sender, args) =>
            {
                Accepted?.Invoke(ImageCameraEnum.TakeCamera, EventArgs.Empty);
                this.Close();
            };
            grid.SetRow(takeImageButton, 2);
            grid.Children.Add(takeImageButton); // Thêm vào hàng 2

            // Nút xóa ảnh
            var deleteButton = new Button
            {
                HeightRequest = 35,
                Text = "Xóa ảnh",
                Margin = 5
            };

            deleteButton.Clicked += (sender, args) =>
            {
                Accepted?.Invoke(ImageCameraEnum.DeleteImage, EventArgs.Empty);
                this.Close();
            };

            grid.SetRow(deleteButton, 3);
            grid.Children.Add(deleteButton); // Thêm vào hàng 3
        }
        else
        {
            // Nút chọn ảnh
            var chooseImageButton = new Button
            {
                HeightRequest = 35,
                Text = "Chọn ảnh từ thiết bị",
                Margin = 5
            };
            chooseImageButton.Clicked += (sender, args) =>
            {
                Accepted?.Invoke(ImageCameraEnum.ChosseFromDevice, EventArgs.Empty);
                this.Close();
            };
            grid.SetRow(chooseImageButton, 0);
            grid.Children.Add(chooseImageButton); // Thêm vào hàng 0

            // Nút chụp ảnh
            var takeImageButton = new Button
            {
                HeightRequest = 35,
                Text = "Chụp ảnh",
                Margin = 5
            };
            takeImageButton.Clicked += (sender, args) =>
            {
                Accepted?.Invoke(ImageCameraEnum.TakeCamera, EventArgs.Empty);
                this.Close();
            };
            grid.SetRow(takeImageButton, 1);
            grid.Children.Add(takeImageButton); // Thêm vào hàng 1
        }

        // Nút đóng
        var closeButton = new Button
        {
            HeightRequest = 37,
            BackgroundColor = Colors.Gray,
            Text = "Đóng",
            Margin = 5
        };

        // Thêm sự kiện Clicked cho nút đóng
        closeButton.Clicked += (sender, args) =>
        {
            this.Close();
        };

        // Thêm closeButton vào gridOrigin ở hàng 2
        gridOrigin.SetRow(closeButton, 2);
        gridOrigin.Children.Add(closeButton);

        // Đặt Grid vào Border
        border.Content = gridOrigin;

        // Thêm Border vào layout trang (ví dụ: nếu bạn đang sử dụng StackLayout trên trang)
        this.Content = new StackLayout
        {
            Children = { border }
        };


    }
}