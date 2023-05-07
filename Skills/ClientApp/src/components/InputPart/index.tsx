import Stack from '@mui/material/Stack';
import Button from '@mui/material/Button';
import { useNavigate, useParams } from 'react-router-dom';
import { useState } from 'react';

export default function BasicButtons() {
    const [isLoading, setIsLoading] = useState(true)

  const handleClose = () => {
    setIsLoading(false)
  }
  const handleToggle = () => {
    setIsLoading(!isLoading)
  }
  const navigate = useNavigate()

  return (
    <Stack spacing={2} direction="row">
      <Button variant="text">LeftSide</Button>
    </Stack>
  );
}