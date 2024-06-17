using System;

class Program
{
    static void Main()
    {
        // Tạo một đối tượng UserProfile với lazy loading
        UserProfile userProfile = new UserProfile("JohnDoe");

        Console.WriteLine("User profile created.");

        // Kiểm tra xem thông tin chi tiết của người dùng đã được tải chưa
        Console.WriteLine("Is user details loaded? " + userProfile.IsDetailsLoaded);

        // Truy cập vào thuộc tính UserDetails để tải thông tin chi tiết của người dùng
        UserDetails details = userProfile.UserDetails;

        Console.WriteLine("User details loaded.");
        Console.WriteLine("Is user details loaded? " + userProfile.IsDetailsLoaded);

        // Hiển thị thông tin chi tiết của người dùng
        Console.WriteLine($"Name: {details.Name}");
        Console.WriteLine($"Email: {details.Email}");
    }
}

class UserProfile
{
    private Lazy<UserDetails> _userDetails;

    public UserProfile(string username)
    {
        Username = username;
        _userDetails = new Lazy<UserDetails>(() => LoadUserDetails(username));
    }

    public string Username { get; }

    public UserDetails UserDetails => _userDetails.Value;

    public bool IsDetailsLoaded => _userDetails.IsValueCreated;

    private UserDetails LoadUserDetails(string username)
    {
        // Giả sử đây là hàm tải thông tin chi tiết từ cơ sở dữ liệu
        Console.WriteLine("Loading user details from database...");
        return new UserDetails { Name = "John Doe", Email = "john.doe@example.com" };
    }
}

class UserDetails
{
    public string Name { get; set; }
    public string Email { get; set; }
}

//Tạo lớp UserProfile:

//Lớp UserProfile chứa một đối tượng Lazy<UserDetails> để tải thông tin chi tiết của người dùng chỉ khi cần thiết.
//Hàm khởi tạo của UserProfile nhận vào một tên người dùng và khởi tạo đối tượng Lazy<UserDetails> với một lambda để gọi hàm LoadUserDetails.
//Tải thông tin chi tiết người dùng:

//Khi thuộc tính UserDetails được truy cập lần đầu tiên, hàm LoadUserDetails sẽ được gọi để tải thông tin chi tiết từ cơ sở dữ liệu (hoặc một nguồn khác).
//Kiểm tra trạng thái tải:

//Thuộc tính IsDetailsLoaded kiểm tra xem thông tin chi tiết của người dùng đã được tải hay chưa bằng cách sử dụng thuộc tính IsValueCreated của đối tượng Lazy<UserDetails>.
//Hiển thị thông tin chi tiết:

//Sau khi truy cập vào thuộc tính UserDetails, thông tin chi tiết của người dùng sẽ được hiển thị.
