resource "aws_ecr_repository" "dotnet" {
  name = "${var.app_name}-dotnet"
}

resource "aws_ecr_repository" "mlapi" {
  name = "${var.app_name}-mlapi"
}
