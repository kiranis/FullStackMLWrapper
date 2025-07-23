resource "aws_ecs_cluster" "this" {
  name = "${var.app_name}-cluster"
}

resource "aws_ecs_task_definition" "dotnet" {
  family                   = "${var.app_name}-dotnet-task"
  requires_compatibilities = ["FARGATE"]
  network_mode            = "awsvpc"
  cpu                     = "256"
  memory                  = "512"
  execution_role_arn      = "arn:aws:iam::YOUR_ACCOUNT_ID:role/ecsTaskExecutionRole"
  container_definitions   = <<DEFINITION
[
  {
    "name": "dotnet-container",
    "image": "YOUR_ECR_IMAGE_URL_DOTNET",
    "essential": true,
    "portMappings": [
      {
        "containerPort": 80,
        "hostPort": 80
      }
    ]
  }
]
DEFINITION
}

resource "aws_ecs_task_definition" "mlapi" {
  family                   = "${var.app_name}-mlapi-task"
  requires_compatibilities = ["FARGATE"]
  network_mode            = "awsvpc"
  cpu                     = "256"
  memory                  = "512"
  execution_role_arn      = "arn:aws:iam::YOUR_ACCOUNT_ID:role/ecsTaskExecutionRole"
  container_definitions   = <<DEFINITION
[
  {
    "name": "mlapi-container",
    "image": "YOUR_ECR_IMAGE_URL_MLAPI",
    "essential": true,
    "portMappings": [
      {
        "containerPort": 5000,
        "hostPort": 5000
      }
    ]
  }
]
DEFINITION
}
