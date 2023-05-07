import { useNavigate, useParams } from 'react-router-dom';
import { useState } from 'react';
import { TextField } from '@mui/material';
import * as React from 'react';
import dayjs, { Dayjs } from 'dayjs';
import { DemoContainer } from '@mui/x-date-pickers/internals/demo';
import { LocalizationProvider } from '@mui/x-date-pickers';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import SkillData from '../skill'

export function InputData() {
  const { cahracterId } = useParams()
  const [isLoading, setIsLoading] = useState(true)

  const [value, setValue] = React.useState<Dayjs | null>(dayjs('2022-04-17'));

  const handleClose = () => {
    setIsLoading(false)
  }
  const handleToggle = () => {
    setIsLoading(!isLoading)
  }
  const navigate = useNavigate()

  return (
    <>
      <TextField id="standard-basic" label="Name" variant="standard" />
      <LocalizationProvider dateAdapter={AdapterDayjs}>
      <DemoContainer components={['DatePicker', 'DatePicker']}>
        <DatePicker
          label="Controlled picker"
          value={value}
          onChange={(newValue) => setValue(newValue)}
        />
      </DemoContainer>
    </LocalizationProvider>
    </>
  );
}