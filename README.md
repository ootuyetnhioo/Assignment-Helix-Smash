| # | Criterion                                           | Specification                                                                                      |
|---|-----------------------------------------------------|----------------------------------------------------------------------------------------------------|
| 1 | Cử động của quả bóng khi người chơi không di chuyển | Quả bóng sẽ nảy lên và nảy xuống tại viên gạch khi không có tương tác của người chơi             |
|   |                                                     | Khi nảy xuống vào viên gạch sẽ phát ra âm thanh                                                    |
|   |                                                     | Âm thanh do các bạn chọn                                                                           |
| 2 | Cử động của quả bóng khi có tương tác của người chơi | Nếu chuột trái được nhấn quả bóng sẽ lao xuống, nếu đi vào các viên gạch trắng viên gạch đó sẽ  |
|   |                                                     | vỡ ra và tạo ra tiếng viên gạch vỡ, nếu va vào viên gạch màu đen sẽ thua và tạo ra tiếng viên  |
|   |                                                     | gạch vỡ                                                                                           |
|   |                                                     | Sau khi phá được 10 viên gạch liên tục sẽ đi vào trạng thái tăng tốc có thể đi qua các viên gạch |
|   |                                                     | đen trong 3 giây                                                                                   |
|   |                                                     | Khi va vào viên gạch đen mà không trong trạng thái tăng tốc, sẽ vỡ ra và thua                     |
| 3 | Trạng thái tăng tốc                                 | Quả bóng sẽ có hiệu ứng lửa cháy                                                                   |
|   |                                                     | Tốc độ lao xuống của quả bóng sẽ tăng                                                             |
|   |                                                     | Khi va vào viên gạch đen sẽ không thua                                                             |
|   |                                                     | Sau 3 giây hiệu ứng sẽ kết thúc                                                                   |
|   |                                                     | Khi phá viên gạch trong quá trình tăng tốc, trạng thái này sẽ được kéo dài thêm                    |
| 4 | Màn chơi bắt đầu và chơi tiếp                      | Màn chơi đầu tiên sẽ có 50 viên gạch                                                               |
|   |                                                     | Khi phá hết 50 viên gạch màn chơi kết thúc, không cho người chơi tương tác và sau 2 giây bắt đầu  |
|   |                                                     | màn chơi mới                                                                                       |
|   |                                                     | Mỗi màn chơi mới sẽ tăng thêm 5 viên gạch                                                          |
| 5 | Màn chơi thua                                       | Khi va vào viên gạch đen, quả bóng sẽ vỡ ra và màn chơi sẽ kết thúc, không cho người chơi tương  |
|   |                                                     | tác sau 2 giây hiện màn hình thua                                                                  |
| 6 | Camera đi theo quả bóng                             | Camera sẽ di chuyển theo quả bóng                                                                 |
|   |                                                     | Khi quả bóng trong trạng thái nảy lên và nảy xuống Camera sẽ không di chuyển theo                  |
| 7 | Màn hình khi bắt đầu trò chơi                      | Khi vừa bắt đầu trò chơi, sẽ có dòng chữ “Click to smash” hiện lên với hiệu ứng mờ dần đi và    |
|   |                                                     | đậm lên                                                                                           |
|   |                                                     | Khi người chơi tương tác lần đầu tiên dòng chữ này sẽ biến mất                                   |
| 8 | Màn hình thua                                      | Màn thua sẽ có thông báo số gạch người đã phá và nút chơi lại                                    |
| 9 | Nút chơi lại                                       | Bắt đầu màn chơi mới và dòng chữ “Click to smash” hiện lên với hiệu ứng mờ dần đi và đậm lên    |
|   |                                                     | Khi người chơi tương tác lần đầu tiên dòng chữ này sẽ biến mất                                   |

![H39_asm3](https://github.com/ootuyetnhioo/Assignment-Helix-Smash/assets/44711219/7489fb44-7ee6-49a6-81f3-ff8c5895b68a)
